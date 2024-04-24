using _0_FrameWork.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operationResult = new OperationResult();
            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                startDate, endDate, command.Reason);
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operationResult = new OperationResult();
            var customerDiscount = _customerDiscountRepository.Get(command.Id);

            if (customerDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
             x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime(); customerDiscount.Edit(command.ProductId, command.DiscountRate,
                 startDate, endDate, command.Reason);

            _customerDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditCustomerDiscount GetDatails(long id)
        {
            return _customerDiscountRepository.GetDatails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
