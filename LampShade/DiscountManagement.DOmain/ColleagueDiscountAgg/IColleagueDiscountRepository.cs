using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using System.Collections.Generic;

namespace DiscountManagement.DOmain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepository<long,ColleagueDiscount>
    {
         EditColleagueDiscount GetDetials(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
