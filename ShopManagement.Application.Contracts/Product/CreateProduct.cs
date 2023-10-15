using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        public CreateProduct()
        {
            Categories = new List<ProductCategoryViewModel>();
        }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //[FileExtensionLimitation(new string[]{".jpg",".jpeg",".png"},ErrorMessage=ValidationMessages.InvalidFileFormat)]
        //[MaxFileSize(3*1024*1024,ErrorMessage=ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; } = string.Empty;
        public string PictureTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        [Range(1, 1000, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }

    }


}
