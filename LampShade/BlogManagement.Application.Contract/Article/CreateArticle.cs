namespace BlogManagement.Application.Contract.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public DateTime PublisDate { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string Metadescription { get; set; }
        public string CanonicalAddress { get; set; }
        public long CategoryId { get; set; }
    }
}