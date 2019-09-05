using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyFirstCoreMVCApp.Repository;

namespace MyFirstCoreMVCApp
{
    public class Startup
    {
        #region ConfigureServices Method
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Exception generated while rendering JSON Data when we use AddMvcCore
            // services.AddMvcCore();

            services.AddSingleton(typeof(IEmployeeRepository), typeof(MockEmployeeRepostitory));
        }
        #endregion

        #region Configure Method
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc();
        }
        #endregion
    }
}
