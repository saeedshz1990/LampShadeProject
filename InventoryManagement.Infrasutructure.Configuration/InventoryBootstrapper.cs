using _0_FrameWork.Infrasutructure;
using _01_LampShadeQuery.Contracts.Inventory;
using _01_LampShadeQuery.Query;
using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrasutructure.Configuration.Permissions;
using InventoryManagement.Infrasutructure.EFCore;
using InventoryManagement.Infrasutructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrasutructure.Configuration
{
    public class InventoryBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();

            services.AddTransient<IInventoryQuery, InventoryQuery>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
