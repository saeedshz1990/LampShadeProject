using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrasutructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrasutructure.EFCore
{
    public class BlogManagementContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public BlogManagementContext(DbContextOptions<BlogManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}