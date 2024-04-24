using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public long ProductId { get; private set; }
        public string Picture { get; private set; } = string.Empty;
        public string PictureAlt { get; private set; } = string.Empty;
        public string PictureTitle { get; private set; } = string.Empty;
        public bool IsRemoved { get; private set; }
        public Product Product { get; private set; }

        public ProductPicture(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }

        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
