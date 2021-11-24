using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
         public EditArticle command;
        public SelectList ArticleCategoris;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            command=_articleApplication.GetDetails(id);
            ArticleCategoris = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
        }
       
    }
}
