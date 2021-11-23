namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IFileUploader fileUploader,
        IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository)
        {
            _fileUploader = fileUploader;
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();

            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Faild(ApplicationMessage.DuplicatedRecored);

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.categoryId);
            var path = $"{categorySlug}/{slug}";

            var pictureName = _fileUploader.Upload(command.picture, path);
            var publishDate=command.PublishDate.ToGoergianDateTime();
            var article = new Article(command.title, command.shortDescription, command.description, pictureName,
        command.pictureAlt, command.pictureTitle, publishDate, slug, command.keyWords, command.metadescription,
        command.canonicalAddress, command.categoryId);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.Successed();
        }
        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.GetWithCategory(command.Id)

            if (article == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);


            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Faild(ApplicationMessage.DuplicatedRecored);

            var slug = command.Slug.Slugify();
            // var categorySlug = _articleCategoryRepository.GetSlugBy(command.categoryId);
            var path = $"{article.Category.Slug}/{slug}";
            var publishDate=command.PublishDate.ToGoergianDateTime();

            var pictureName = _fileUploader.Upload(command.picture, path);
            article.Edit(command.title, command.shortDescription, command.description, pictureName,
        command.pictureAlt, command.pictureTitle, publishDate, slug, command.keyWords, command.metadescription,
        command.canonicalAddress, command.categoryId);

            _articleRepository.SaveChanges();
            return operation.Successed();

        }
        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);

        }
        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);

        }
    }
}