using _0_FrameWork.Application;
using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.Comment;
using BlogManagement.Infrasutructure.EFCore;
using CommentManagement.Infrasutructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogManagementContext _context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogManagementContext context, CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = _context.Articles
             .Include(x => x.Category)
             .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
             {
                 Id = x.Id,
                 Slug = x.Slug,
                 Title = x.Title,
                 Picture = x.Picture,
                 KeyWords = x.KeyWords,
                 PublisDate = x.PublishDate.ToFarsi(),
                 PictureAlt = x.PictureAlt,
                 CategoryId = x.CategoryId,
                 Description = x.Description,
                 PictureTitle = x.PictureTitle,
                 CategoryName = x.Category.Name,
                 CategorySlug = x.Category.Slug,
                 CanonicalAddress = x.CanonicalAddress,
                 Metadescription = x.Metadescription,
                 ShortDescription = x.ShortDescription
             }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(article.KeyWords))
                article.KeyWordList = article.KeyWords.Split(",").ToList();


            var comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ParentId = x.ParentId,
                    WEbsite = x.Website
                }).OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId > 0)
                    comment.ParentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;

            }
            article.Comments = comments;

            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _context.Articles
            .Include(x => x.Category)
            .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
            {
                Slug = x.Slug,
                Title = x.Title,
                Picture = x.Picture,
                PublisDate = x.PublishDate.ToFarsi(),
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription
            }).ToList();
        }
    }
}