using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
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

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
