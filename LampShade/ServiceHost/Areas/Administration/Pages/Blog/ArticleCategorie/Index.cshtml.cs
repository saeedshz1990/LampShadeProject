using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel;

        //ProducCategoryViewModel use for Save
        public List<ArticleCategoryViewModel> ArticleCategories;

        private readonly IArticleApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create",new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _articleCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
  
            var result = _articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }


    }
}