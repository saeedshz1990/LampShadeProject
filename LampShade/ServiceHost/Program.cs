using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ServiceHost
{
    public static class Program
    {

        //Public void Main()
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        //Public
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
