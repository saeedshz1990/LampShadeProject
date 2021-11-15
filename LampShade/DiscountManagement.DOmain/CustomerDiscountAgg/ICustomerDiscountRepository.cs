using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System.Collections.Generic;

namespace DiscountManagement.DOmain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long,CustomerDiscount>
    {
        EditCustomerDiscount GetDatails(long id);
        List<CustomerDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
