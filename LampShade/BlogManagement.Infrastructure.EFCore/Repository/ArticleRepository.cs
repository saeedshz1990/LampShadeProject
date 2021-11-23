namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IAr.ticleRepository
    {

        private readonly BlogManagementContext _context;

        public ArticleRepository(BlogManagementContext context) : base(context)
        {
            _context = context;
        }

        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                Title = x.Title,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                KeyWords = x.KeyWords,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi()

            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription=x.ShortDescription
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Title))
                query=query.Where(x=>x.Title.Contains(searchModel.Title));

                if(searchModel.CategoryId > 0)
                query=query.Where(x=>x.CategoryId(searchModel.CategoryId));


                return query.ORderByDescending(x=>x.Id).ToList();
        }
        public Article GetWithCategory(long id)
        {
             return _context.Articles.Include(x =>x.Category).FirstOrDefault(x=>x.Id==id);
        }
    }
}