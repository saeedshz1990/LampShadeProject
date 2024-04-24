namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; } = string.Empty;
        public int DiscountRate { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public DateTime StartDateGR { get; set; }
        public string EndDate { get; set; } = string.Empty;
        public DateTime EndDateGR { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;

    }
}
