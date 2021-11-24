using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        public CreateArticle command;
        public SelectList ArticleCategoris;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategoris = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
        }
    }
}
