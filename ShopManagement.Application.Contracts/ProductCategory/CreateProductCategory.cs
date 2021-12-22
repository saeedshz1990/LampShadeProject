﻿using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage=ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string Description { get;  set; }

        // [Required(ErrorMessage=ValidationMessages.IsRequired)]
        [FileExtensionLimitation(new string[]{".jpg",".jpeg",".png"},ErrorMessage=ValidationMessages.InvalidFileFotmat)]
        [MaxFileSize(3*1024*1024,ErrorMessage=ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)] 
        public string Slug { get;  set; }
    }
}