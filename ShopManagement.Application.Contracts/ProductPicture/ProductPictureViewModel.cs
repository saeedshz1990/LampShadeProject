namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public long ProductId { get; set; }
        public bool IsRemoved { get; set; }
    }

}
