using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using _0_FrameWork.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long , ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        EditArticleCategory GetDetails(long id);

         string GetSlugById(long id);
        List<ProductCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
