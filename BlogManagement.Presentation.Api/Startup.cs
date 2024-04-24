using _0_FrameWork.Application;
using BlogManagement.Infrasutructure.Configuration;
using CommentManagement.Infrasutructure.Configuration;
using ServiceHost;

namespace BlogManagement.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("LampshadeDb");
            BlogManagementBootstrapper.Configure(services, connectionString);
            CommentManagementBootstraper.Configure(services, connectionString);
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}