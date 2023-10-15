using ShopManagement.Domain.ProductCategoryAgg;
using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;


namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {

        public Product()
        {
            ProductPictures=new List<ProductPicture>();
        }

        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string ShortDescription { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Picture { get; private set; } = string.Empty;
        public string PictureAlt { get; private set; } = string.Empty;
        public string PictureTitle { get; private set; } = string.Empty;
        public string KeyWords { get; private set; } = string.Empty;
        public string MetaDescription { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }



        public Product(string name, string code,
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string keyWords,
            string metaDescription, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
            
        }


        public void Edit(string name, string code, 
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string keyWords,
            string metaDescription, string slug, long categoryId)
        {
            Name = name;
            Code = code;

            ShortDescription = shortDescription;
            Description = description;
            
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            CategoryId = categoryId;
        }

       

    }
}
