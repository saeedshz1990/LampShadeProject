using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; } = string.Empty;
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureAlt { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string PictureTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int ShowOrder { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Metadescription { get; set; } = string.Empty;


        public string CanonicalAddress { get; set; } = string.Empty;
    }
}