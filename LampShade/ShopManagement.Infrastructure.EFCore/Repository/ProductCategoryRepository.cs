using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using _0_FrameWork.Infrasutructure;
using _0_Framework.Application;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> , IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x=> new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
              
            }).ToList();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditArticleCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                // Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();

        }

        public string GetSlugById(long id)
        {
            return _context.ProductCategories.Select(x=> new {x.Id , x.Slug}).FirstOrDefault(x=>x.Id==id).Slug;
        }
    }
}
