using System.Collections.Generic;
using _01_LampShadeQuery.Contracts.Article;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogManagementContext _context;

        public ArticleQuery(BlogManagementContext context)
        {
            _context = context;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = _context.Articles
             .Include(x => x.Category)
             .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
             {
                 CategoryId = x.CategoryId,
                 CategoryName = x.CategoryName,
                 CategorySlug = x.CategorySlug,
                 Slug = x.Slug,
                 CanonicalAddress = x.CanonicalAddress,
                 Description = x.Description,
                 KeyWords = x.KeyWords,
                 Metadescription = x.Metadescription,
                 Picture = x.Picture,
                 PictureAlt = x.PictureAlt,
                 PictureTitle = x.PictureTitle,
                 PublisDate = x.PublisDate,
                 ShortDescription = x.ShortDescription,
                 Title = x.Title
             }).FirstOrDefault(x => x.Slug == slug);
             
                article.KeyWordList=article.KeyWords.Split(",").ToList();

             return article;
        }

        public List<ArticleQueryModel> LatestArtticles()
        {
            return _context.Articles
            .Include(x => x.Category)
            .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
            {
                Slug = x.Slug,
                Title = x.Title,
                Picture = x.Picture,
                PublisDate = x.PublisDate,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription
            }).TOList();
        }
    }
}