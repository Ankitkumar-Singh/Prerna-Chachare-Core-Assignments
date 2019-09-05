using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDBOperations.Models;
using MyDBOperations.Repository;

namespace MyDBOperations
{
    public class Startup
    {
        IConfiguration _configuration;

        public Startup(IConfiguration configuration) =>
            _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddDbContextPool<MyDBContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("EmployeeDBConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}
