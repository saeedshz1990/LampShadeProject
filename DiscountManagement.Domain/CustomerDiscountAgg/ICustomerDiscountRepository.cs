using _0_FrameWork.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using System.Collections.Generic;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long,CustomerDiscount>
    {
        EditCustomerDiscount GetDatails(long id);
        List<CustomerDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
