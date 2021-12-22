using _0_FrameWork.Application;
using BlogManagement.Infrasutructure.Configuration;
using CommentManagement.Infrasutructure.Configuration;
using DiscountManagement.Infrasutructure.Configuration;
using InventoryManagement.Infrasutructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Infrasutructure.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ServiceHost
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
            var connectionString = Configuration.GetConnectionString("LampShadeDB");
            ShopManagementBootstraper.Configure(services, connectionString);
            DiscountManagmentBootsraper.Configure(services, connectionString);
            InventoryBootstrapper.Configure(services, connectionString);
            BlogManagementBootstrapper.Configure(services, connectionString);
            CommentManagementBootstraper.Configure(services, connectionString);

            services.AddSingleton(HtmlEncoder.
                Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));

            services.AddTransient<IFileUploader, FileUploader>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
