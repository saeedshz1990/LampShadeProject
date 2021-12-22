using _0_FrameWork.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        EditArticleCategory GetDetails(long id);
        OperationResult Edit(EditArticleCategory command);
        List<ArticleCategoryViewModel> GetArticleCategories();
        OperationResult Create(CreateArticleCategory command);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);


    }
}