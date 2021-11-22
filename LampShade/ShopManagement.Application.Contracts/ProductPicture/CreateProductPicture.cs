using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,100000,ErrorMessage = ValidationMessages.IsRequired)]
        public long  ProductId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        [FileExtensionLimitation(new string[]{".jpg",".jpeg",".png"},ErrorMessage=ValidationMessages.InvalidFileFotmat)]
        [maxFileSize(1*1024*1024,ErrorMessage=ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }

}
