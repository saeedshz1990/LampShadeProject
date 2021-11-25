using System;

namespace CommentManagement.Infrastructure.Configuration
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
