using System.Collections.Generic;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id); 
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
    }
}
