using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MyFirstCoreApplication
{
    public class Program
    {
        #region Main method
        // Main method 
        public static void Main(string[] args) =>
            CreateWebHostBuilder(args).Build().Run();
        #endregion

        #region CreateWebHostBuilder Method
        // CreateWebHostBuilder Method
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseWebRoot("Content")
                .UseStartup<Startup>();
        #endregion
    }
}
