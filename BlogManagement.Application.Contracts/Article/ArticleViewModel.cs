namespace BlogManagement.Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;    
        public string Picture { get; set; } = string.Empty;
        public string PublisDate { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public long CategoryId { get; set; }

    }
}