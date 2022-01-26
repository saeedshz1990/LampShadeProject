using _0_FrameWork.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;

        public AccountApplication(IAccountRepository accountRepository, 
            IPasswordHasher passwordHasher,IFileUploader fileUploader)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation=new OperationResult();
            var account=_accountRepository.Get(command.Id);
            if(account==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordNotMatch);

            var password=_passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Create(CreateAccount command)
        {
            var operation = new OperationResult();

            if(_accountRepository.Exists(x=>x.Username==command.Username|| x.Mobile==command.Mobile))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"ProfilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var password = _passwordHasher.Hash(command.Password);
            var account = new Account(command.Fullname,command.Username, password,
                command.Mobile,command.RoleId, picturePath);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x => (x.Username == command.Username || x.Mobile == command.Mobile )&& x.Id !=command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"ProfilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username,
                command.Mobile, command.RoleId, picturePath);
            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchodel searchodel)
        {
            return _accountRepository.Search(searchodel);
        }
    }
}
