using System.Collections.Generic;
using _01_LampShadeQuery.Contracts.ArticleCategory;

namespace _01_LampShadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogManagementContext _context;

        public ArticleCategoryQuery(BlogManagementContext context)
        {
            _context = context;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _context.ArticleCategory
            .Include(x=>x.Articles).Select(x=> new ArticleCategoryQueryModel
            {
                Name=x.Name,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug,
                ArticlesCount=x.Article.Count 
            }).ToList();
        }
    }
}