using CommentManagement.Application;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrasutructure.EFCore;
using CommentManagement.Infrasutructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Infrasutructure.Configuration
{
    public class CommentManagementBootstraper
    {

        public static void Configure(IServiceCollection services, string connectionString)
        {

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddDbContext<CommentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
