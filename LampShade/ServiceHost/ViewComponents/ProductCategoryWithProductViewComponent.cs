using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public LatestArrivalsViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var categories=_productCategoryQuery.GetProductCategoriesWithProducts();
            return View(categories);
            
        }
    }
}
