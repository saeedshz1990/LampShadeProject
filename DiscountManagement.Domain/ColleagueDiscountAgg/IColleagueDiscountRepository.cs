using _0_FrameWork.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using System.Collections.Generic;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepository<long,ColleagueDiscount>
    {
         EditColleagueDiscount GetDetials(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
