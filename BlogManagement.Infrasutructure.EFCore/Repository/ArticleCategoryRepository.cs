using _0_FrameWork.Application;
using _0_FrameWork.Infrasutructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrasutructure.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogManagementContext _context;

        public ArticleCategoryRepository(BlogManagementContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _context.ArticleCategories
            .Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
        public EditArticleCategory GetDetails(long id)
        {
            return _context.ArticleCategories.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Metadescription = x.Metadescription,
                CanonicalAddress = x.CanonicalAddress,
                Slug = x.Slug,
                KeyWords = x.KeyWords,
                ShowOrder = x.ShowOrder,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);

        }
        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Include(x => x.Articles)
            .Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Picture = x.Picture,
                ShowOrder = x.ShowOrder,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCount = x.Articles.Count
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }

        public string GetSlugBy(long id)
        {
            return _context.ArticleCategories
            .Select(x => new { x.Id, x.Slug })
            .FirstOrDefault(x => x.Id == id).Slug;
        }
    }
}