namespace BlogManagement.Application.Contract.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Title { get; set; }


        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public DateTime PublisDate { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Metadescription { get; set; }

        public string CanonicalAddress { get; set; }

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessage.IsRequired)]
        public long CategoryId { get; set; }
    }
}