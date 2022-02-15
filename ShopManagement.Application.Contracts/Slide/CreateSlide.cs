﻿using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        [FileExtensionLimitation(new string[]{".jpg",".jpeg",".png"},ErrorMessage=ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1*1024*1024,ErrorMessage=ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get;  set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get;  set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Text { get;  set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BtnText { get; set; }
         [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get; set; }

    }

   
}
