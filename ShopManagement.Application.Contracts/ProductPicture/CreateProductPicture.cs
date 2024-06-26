﻿using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {

        public CreateProductPicture()
        {
            Products = new List<ProductViewModel>();
        }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        [FileExtensionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; } = string.Empty;
        public List<ProductViewModel> Products { get; set; }

    }

}
