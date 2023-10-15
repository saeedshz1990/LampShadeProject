namespace ShopManagement.Application.Contracts.Product
{
    //For Admin Display
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public string Creationdate { get; set; } = string.Empty;
     }
}