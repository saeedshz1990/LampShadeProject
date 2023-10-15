using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;

        public IFormFile Picture { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }=string.Empty;

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PublishDate { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; } = string.Empty;

        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLenght)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Metadescription { get; set; }= string.Empty;

        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLenght)]
        public string CanonicalAddress { get; set; } = string.Empty;

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }
    }
}