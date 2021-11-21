using _01_LampShadeQuery.Contracts.Product.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            var arrivals=_productQuery.GetLatestArrivals();
            return View(arrivals);
            
        }
    }
}
