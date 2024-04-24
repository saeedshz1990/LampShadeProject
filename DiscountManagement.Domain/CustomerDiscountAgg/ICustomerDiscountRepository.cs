using _0_FrameWork.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscount;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscount>
    {
        EditCustomerDiscount GetDatails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
