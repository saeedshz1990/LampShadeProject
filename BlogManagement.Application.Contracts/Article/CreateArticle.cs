using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }


        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PublishDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Metadescription { get; set; }

        public string CanonicalAddress { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }
    }
}