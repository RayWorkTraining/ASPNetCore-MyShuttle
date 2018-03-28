using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyShuttle.Web.AppBuilderExtensions;
using Microsoft.Extensions.Configuration;
using MyShuttle.Model;
using Microsoft.AspNetCore.Identity;
using MyShuttle.Data;

namespace MyShuttle
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var config = new ConfigurationBuilder().AddJsonFile("config.json", optional: true).SetBasePath(env.ContentRootPath).Build();
            Configuration = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataContext(Configuration);

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MyShuttleContext>().AddDefaultTokenProviders();

            services.ConfigureDependencies();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureRoutes();
        }

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseMvc(routes =>
        //    {
        //        routes.MapRoute(name: "Default", template: "{controller}/{action}/{id?}", defaults: new { controller = "Home", action = "Index" });
        //    });

        //    //app.Run(async (context) =>
        //    //{
        //    //    await context.Response.WriteAsync("Hello World!");
        //    //});
        //}
    }
}
