using _0_FrameWork.Application;
using _0_FrameWork.Infrasutructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrasutructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogManagementContext _context;

        public ArticleRepository(BlogManagementContext context) : base(context)
        {
            _context = context;
        }

        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                KeyWords = x.KeyWords,
                Metadescription = x.Metadescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                PublisDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "....."
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);


            return query.OrderByDescending(x => x.Id).ToList();
        }
        public Article GetWithCategory(long id)
        {
            return _context.Articles.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }
    }
}