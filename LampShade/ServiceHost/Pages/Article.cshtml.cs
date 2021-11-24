using System.Collections.Generic;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> articleCategories;
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleModel(IArticleQuery articleQuery , IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery=articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            Article=_articleQuery.GetArticleDetails(id);
            LatestArticles=_articleQuery.LatestArtticles();
            articleCategories=_articleCategoryQuery.GetArticleCategories();
        }
    }
}
