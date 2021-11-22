namespace BlogManagement.Application.Contract.ArticleCategory
{
    public class CreateArticleCategory
    {
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string Description { get; set; }
        public int ShowOrder { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string Metadescription { get; set; }
        public string CanonicalAddress { get; set; }
    }
}