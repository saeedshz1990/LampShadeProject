using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Application;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Infrasutructure.EFCore;
using Microsoft.EntityFrameworkCore;

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
            return _context.ArticleCategories
            .Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ArticlesCount = x.Articles.Count
            }).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var articleCategory =  _context.ArticleCategories
            .Include(x=>x.Articles)
            .Select(x => new ArticleCategoryQueryModel
            {
                Name = x.Name,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description=x.Description,
                KeyWords=x.KeyWords,
                Metadescription=x.Metadescription,
                CanonicalAddress=x.CanonicalAddress, 
                Articles=MapArticles(x.Articles),
                // KeyWordList=x.KeyWords.Split(),
                ArticlesCount=x.Articles.Count
            }).FirstOrDefault(x => x.Slug == slug);

            if(!string.IsNullOrWhiteSpace(articleCategory.KeyWords))
                articleCategory.KeyWordList=articleCategory.KeyWords.Split(",").ToList();

            return articleCategory;
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> articles)
        {
            return articles.Select(x=> new ArticleQueryModel
            {
                 Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,   
                 ShortDescription=x.ShortDescription,
                 Title=x.Title,
                 PublisDate=x.PublishDate.ToFarsi()
            }).ToList();

        }



    }
}