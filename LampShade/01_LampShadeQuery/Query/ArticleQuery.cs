using System.Collections.Generic;
using _01_LampShadeQuery.Contracts.Article;

namespace _01_LampShadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogManagementContext _context;
        private readonly CommentManagementContext _commentContext;

        public ArticleQuery(BlogManagementContext context ,CommentManagementContext  commentContext )
        {
            _context = context;
            _commentContext=commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = _context.Articles
             .Include(x => x.Category)
             .Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
             {
                 Id=x.Id,
                 Slug = x.Slug,
                 Title = x.Title,
                 Picture = x.Picture,
                 KeyWords = x.KeyWords,
                 PublisDate = x.PublisDate,
                 PictureAlt = x.PictureAlt,
                 CategoryId = x.CategoryId,
                 Description = x.Description,
                 PictureTitle = x.PictureTitle,
                 CategoryName = x.CategoryName,
                 CategorySlug = x.CategorySlug,
                 CanonicalAddress = x.CanonicalAddress,
                 Metadescription = x.Metadescription,
                 ShortDescription = x.ShortDescription
             }).FirstOrDefault(x => x.Slug == slug);
             
              if(!string.IsNullOrWhiteSpace(article.KeyWords))
                article.KeyWordList=article.KeyWords.Split(",").ToList();


                var comments = _commentContext.Comments
                    .Where(x => !x.IsCanceled)
                    .Where(x => x.IsConfirmed)
                    .Where(x => x.CommentType.Article)
                    .Where(x => x.OwnerRecordId == article.Id)
                    .Select(x => new CommentQueryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Message = x.Message,
                        CreationDate=x.CreationDate.ToFarsi(),
                        ParentId=x.ParentId,
                        WEbsite=x.WEbsite
                    }).OrderByDescending(x => x.Id).ToList();

                foreach (var comment in commentss)
                {
                    if(comment.ParentId > 0)
                        comment.ParentName=comments.FirstOrDefault(x=>x.Id==comment.ParentId)?.Name;
                    
                }
                article.comments=comments;

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