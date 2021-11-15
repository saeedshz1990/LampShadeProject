using _0_FrameWork.Domain;
using System;

namespace DiscountManagement.DOmain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        //public DateTime StartDateGR { get; private set; }
        public DateTime EndDate { get; private set; }
        //public DateTime EndDateGR { get; private set; }
        public string Reason { get; private set; }
        //public bool IsRemoved { get; private set; }


        public CustomerDiscount(long productId, int discountRate, DateTime startDate,
            DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

       
        //all Item Editable
        public void  Edit(long productId, int discountRate, DateTime startDate,
            DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }



    }
}
