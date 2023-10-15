namespace ShopManagement.Application.Contracts.Product
{
    public class ProductSearchModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public long CategoryId { get; set; }

    }
}