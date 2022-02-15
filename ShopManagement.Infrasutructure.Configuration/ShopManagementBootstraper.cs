using _0_FrameWork.Infrasutructure;
using _01_LampShadeQuery.Contracts;
using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using _01_LampShadeQuery.Contracts.Slide;
using _01_LampShadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.AccountAcl;
using ShopManagement.Infrastructure.InventoryAcl;
using ShopManagement.Infrasutructure.Configuration.Permissions;
using ShopManagement.Infrasutructure.EFCore;
using ShopManagement.Infrasutructure.EFCore.Repository;

namespace ShopManagement.Infrasutructure.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderApplication, OrderApplication>();

            services.AddSingleton<ICartService, CartService>();

            services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();
            services.AddTransient<IShopAccountAcl, ShopAccountAcl>();

            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddTransient<IProductQuery, ProductQuery>();
            services.AddTransient<ICartCalculatorService, CartCalculatorService>();

            services.AddTransient<IPermissionExposer, ShopPermissionExposer>();


            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
