namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ShowOrder { get; set; }
        public string CreationDate { get; set; } = string.Empty;
        public long ArticleCount { get; set; }


    }
}