namespace BlogManagement.Infrastructure.EFCore
{
    public class BlogManagementContext :DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        
        
        public BlogManagementContext(DbContextOptions<BlogManagementContext> options) : base(options)
        {
            
        }



        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ArticleCategoryMapping).Assembly();
            modelBuilder.ApplyConfigurationFromAssembly(assembly);

            base.OnModelCreating(modelBuilder); 

        }
    }
}