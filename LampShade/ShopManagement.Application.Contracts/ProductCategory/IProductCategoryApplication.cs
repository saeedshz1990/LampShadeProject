using System.Collections.Generic;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(long id); 
        List<ProductCategoryViewModel> Search(ArticleCategorySearchModel searchModel);

        List<ProductCategoryViewModel> GetProductCategories();
    }
}
