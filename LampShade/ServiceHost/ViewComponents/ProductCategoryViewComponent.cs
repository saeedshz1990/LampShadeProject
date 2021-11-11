using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _iproductcategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery iproductcategoryQuery)
        {
            _iproductcategoryQuery = iproductcategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategories = _iproductcategoryQuery.GetProductCategories();
            return View(productCategories);
        }
    }
}
