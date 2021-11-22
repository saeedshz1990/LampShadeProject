namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogManagementContext _context;

        public ArticleCategoryRepository(BlogManagementContext context) : base(context)
        {
            _context = context;
        }

        EditArticleCategory GetDetails(long id)
        {
            return _context.ArticleCategories.Select(x => new EditArticleCategory
            {
                id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                Slug = x.Slug,
                KeyWords = x.KeyWords,
                ShowOrder = x.ShowOrder
            }).FirstOrDefault(x => x.Id == id);


        }
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query= _context.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id=x.Id,
                Name=x.Name,
                Description=x.Description,
                Picture=x.Picture,
                ShowOrder=x.ShowOrder

            });
            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));


                return query.OrderByDescending(x=>x.ShowOrder).ToList();


        }
    }
}