﻿using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Name { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }

        //[FileExtensionLimitation(new string[]{".jpg",".jpeg",".png"},ErrorMessage=ValidationMessages.InvalidFileFormat)]
        //[MaxFileSize(3*1024*1024,ErrorMessage=ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }

        [Range(1,1000,ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get;  set; }
        public List<ProductCategoryViewModel> Categories { get; set; }

    }

    
}
