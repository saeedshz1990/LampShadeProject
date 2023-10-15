namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public class ColleagueDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; } = string.Empty;
        public int DiscountRate { get; set; }
        public string CreationDate { get; set; } = string.Empty;
        public bool IsRemoved { get; set; }

    }
}
