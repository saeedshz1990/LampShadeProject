using System.Collections.Generic;
using _0_FrameWork.Infrasutructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Infrasutructure.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    //[Authorize(Roles ="1")]
    public class IndexModel : PageModel
    {
        public ProductCategoryViewModel SearchModel;

        //ProducCategoryViewModel use for Save
        public List<ProductCategoryViewModel> ProductCategories;

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        [NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateProductCategory());
        }

        [NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        [NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if(ModelState.IsValid)
            {
                
            }
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }


    }
}