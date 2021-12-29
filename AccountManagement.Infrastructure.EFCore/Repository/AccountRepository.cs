using _0_FrameWork.Infrasutructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Account.Select(x => new EditAccount
            {
                Id = id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,  
                RoleId = x.RoleId,      
                Username=x.Username
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<AccountViewModel> Search(AccountSearchodel searchodel)
        {
            var query= _context.Account.Select(x => new AccountViewModel {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                Username = x.Username,
                ProfilePhoto=x.ProfilePhoto,
                RoleId=2,
                Role="مدیرسیستم"
            });

            if (!string.IsNullOrWhiteSpace(searchodel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchodel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchodel.Username))
                query = query.Where(x => x.Username.Contains(searchodel.Username));

            if (!string.IsNullOrWhiteSpace(searchodel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchodel.Mobile));

            if (searchodel.RoleId>0)
                query=query.Where(x=> x.RoleId==searchodel.RoleId);

                return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
