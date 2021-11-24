namespace BlogManagement.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryAppdlication
    {
        EditArticleCategory GetDetails(long id);
        OperationResult Edit(EditArticleCategory command);
        List<ArticleCategoryViewModel> GetArticleCategories();
        OperationResult Create(CreateArticleCategory command);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);


    }
}