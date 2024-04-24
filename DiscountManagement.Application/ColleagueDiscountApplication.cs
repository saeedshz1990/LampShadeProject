using _0_FrameWork.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operationResult = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);

            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operationResult = new OperationResult();
            var colleageDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleageDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            colleageDiscount.Edit(command.ProductId, command.DiscountRate);

            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditColleagueDiscount GetDetials(long id)
        {
            return _colleagueDiscountRepository.GetDetials(id);
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var colleageDiscount = _colleagueDiscountRepository.Get(id);
            if (colleageDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            colleageDiscount.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var colleageDiscount = _colleagueDiscountRepository.Get(id);
            if (colleageDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            colleageDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
