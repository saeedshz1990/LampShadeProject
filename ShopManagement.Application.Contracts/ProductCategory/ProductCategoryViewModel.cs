namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public long ProductsCount { get; set; }

    }
}
