namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {
        public long ProductId { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
    }
}
