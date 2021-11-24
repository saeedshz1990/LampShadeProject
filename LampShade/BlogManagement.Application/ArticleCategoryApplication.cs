namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }

        OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.upload(command.Picture, slug);
            var articleCategory = new ArticleCategory(command.Name, pictureName,command.PictureAlt,command.PictureTitle, command.Description,
            slug, command.ShowOrder, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Successed();


        }
        OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategories = _articleCategoryRepository.Get(command.id);

            if (articleCategories == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id == command.Id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.upload(command.Picture, slug);

            articleCategories.Edit(command.Name, pictureName, command.Description,command.PictureAlt,command.PictureTitle,
            slug, command.ShowOrder, command.KeyWords, command.MetaDescription, command.CanonicalAddress);


            _articleCategoryRepository.SaveChanges();
            return operation.Successed();


        }
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);

        }
        EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }
    }
}