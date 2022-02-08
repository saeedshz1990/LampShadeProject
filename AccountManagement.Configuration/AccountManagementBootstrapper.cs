using Microsoft.Extensions.DependencyInjection;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EFCore.Repository;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddDbContext<AccountContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}
