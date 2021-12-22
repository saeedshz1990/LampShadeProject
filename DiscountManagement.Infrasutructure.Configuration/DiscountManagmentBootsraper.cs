using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrasutructure.EFCore;
using DiscountManagement.Infrasutructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Infrasutructure.Configuration
{
    public class DiscountManagmentBootsraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();


            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();



            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
