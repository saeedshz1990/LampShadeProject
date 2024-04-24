using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // [Required(ErrorMessage=ValidationMessages.IsRequired)]
        [FileExtensionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; } = string.Empty;
        public string PictureTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; } = string.Empty;
    }
}
