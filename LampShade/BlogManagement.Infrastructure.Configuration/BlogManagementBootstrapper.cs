using System;

namespace BlogManagement.Infrastructure.Configuration
{
    public class BlogManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();

            services.AddTransient<IArticleQuery,ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery,ArticleCategoryQuery>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
