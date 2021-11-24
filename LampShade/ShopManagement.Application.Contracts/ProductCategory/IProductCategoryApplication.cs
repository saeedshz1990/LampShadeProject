using System.Collections.Generic;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(long id); 
        List<ProductCategoryViewModel> Search(ArticleSearchModel searchModel);

        List<ProductCategoryViewModel> GetProductCategories();
    }
}
