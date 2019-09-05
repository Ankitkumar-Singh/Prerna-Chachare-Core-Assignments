using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyFirstCoreApplication
{
    public class Startup
    {
        #region IConfiguration object
        // The IConfiguration object.
        private IConfiguration _configuration;
        #endregion

        #region Startup Constructor
        // The constructor of Startup class with a IConfiguration object.
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Configure Services Method
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        #endregion

        #region Configure Method
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseWelcomePage();

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(_configuration["MyKey"]);
                await context.Response.WriteAsync("\nHello from Use Main\n");
                await context.Response.WriteAsync("\nFrom A (before)\n");
                await next();
                await context.Response.WriteAsync("\nFrom A (after)\n");
            });

            app.UseWhen(
                context => context.Request.Path.StartsWithSegments(new PathString("/UseWhen")),
                a => a.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("\nFrom B (before)\n");
                    await next();
                    await context.Response.WriteAsync("\nFrom B (after)\n");
                }));

            app.Map("/map", MyMiddleware);

            app.Map("/map1",
                FirstMiddleware => FirstMiddleware.Map("/map1a",
                SecondMiddleware => SecondMiddleware.Run(async (context) =>
                await context.Response.WriteAsync("Hello from Nested Middleware\n"))));

            app.Run(async context => await context.Response.WriteAsync("From Run Main"));
        }
        #endregion

        #region MyMiddlewareAsync Method
        // The MyMidddlewareAsync method with HttpContext's object as a parameter.
        private static void MyMiddlewareAsync(IApplicationBuilder applicationBuilder) =>
            applicationBuilder.Run(async (context) =>
            await context.Response.WriteAsync("Hello from Run Middleware\n"));
        #endregion

        #region MyMiddleware Method
        // The MyMiddleware method with IApplicationBuilder's objct as a parameter.
        public static void MyMiddleware(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Map Use Middleware\n");
                await next();
            });

            app.MapWhen(context => context.Request.Query.ContainsKey("branch"), MyMiddlewareAsync);

            app.Run(async (context) =>
            await context.Response.WriteAsync("Hello from Map Run Middleware\n"));
        }
        #endregion
    }
}
