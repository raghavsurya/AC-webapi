using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdiddaClub.WebApi.Database;
using AdiddaClub.WebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace AdiddaClub.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            
            services.AddApplicationInsightsTelemetry(Configuration);

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddTransient<IMongoRepository, MongoRepository>();

            //This is to map the Object Id and get it as a string
            //BsonClassMap.RegisterClassMap<PlayerStatistics>(cm =>
            //{
            //    cm.AutoMap();
            //    cm.SetIdMember(cm.GetMemberMap(c => c.Id));

            //});
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
        //    var trackPackageRouteHandler = new RouteHandler(context =>
        //    {
        //        var routeValues = context.GetRouteData().Values;
        //        return context.Response.WriteAsync(
        //            $"Hello! Route values: {string.Join(", ", routeValues)}");
        //    });
        //    var routes = new Rout(app, trackPackageRouteHandler);
        //    routes.MapHttpRoute(
        //    name: "ApiRoot",
        //    routeTemplate: "api/root/{id}",
        //    defaults: new { controller = "products", id = RouteParameter.Optional }
        //);
        //            routes.MapHttpRoute(
        //                name: "DefaultApi",
        //                routeTemplate: "api/{controller}/{id}",
        //                defaults: new { id = RouteParameter.Optional }
        //            );
            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "api/{controller}/{id?}");
            //});
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
        }
    }
}
