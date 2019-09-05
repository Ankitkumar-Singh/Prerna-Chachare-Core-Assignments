using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MyFirstCoreMVCApp
{
    public class Program
    {
        #region Main method
        // Main Method
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();
        #endregion

        #region CreateWebHostBuilder Method
        // CreateWebHostBuilder Method
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
    }
}
