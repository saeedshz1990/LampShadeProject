using _01_LampShadeQuery.Contracts.Product.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using _01_LampShadeQuery.Contracts.Slide;
using _01_LampShadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.CommentAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            //PRoductCategory
            services.AddTransient<IArticleApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            //Product
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();
            //ProductPicture
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository,ProductPictureRepository>();
            //Slide
            services.AddTransient<ISlideRepository, SlideRepository>();
            services.AddTransient<ISlideApplication, SlideApplication>();
            //Query
            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
         
            services.AddTransient<IProductQuery, ProductQuery>();

            //Comment
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();
 

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
