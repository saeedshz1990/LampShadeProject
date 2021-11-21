using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampShadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.ProductCategory
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategory(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery=productCategoryQuery;
        }
        public void OnGet(string id)
        {
            ProductCategory=_productCategoryQuery.GetProductCategoryWithProductsBy(id);
            
        }
    }
}
