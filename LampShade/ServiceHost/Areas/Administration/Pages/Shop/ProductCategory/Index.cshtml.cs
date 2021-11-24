using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel;

        //ProducCategoryViewModel use for Save
        public List<ProductCategoryViewModel> ProductCategories;

        private readonly IArticleApplication _productCategoryApplication;

        public IndexModel(IArticleApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            if(ModelState.IsValid)
            {
                
            }
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }


    }
}