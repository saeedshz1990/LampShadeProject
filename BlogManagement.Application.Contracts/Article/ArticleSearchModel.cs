using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Application.Contracts.Article
{
    public class ArticleSearchModel
    {
        public ArticleSearchModel()
        {
            Categories = new List<ArticleCategoryViewModel>();
        }

        public string Title { get; set; } = string.Empty;
        public long CategoryId { get; set; }
        public List<ArticleCategoryViewModel> Categories { get; set; }


    }
}