using _0_FrameWork.Application;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        EditCustomerDiscount GetDatails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
