using RepositoryLayer.Extensions;
using ServiceLayer.Extensions;
using Serilog.Sinks.RollingFile;
using Serilog.Sinks.Async;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Microsoft.AspNetCore.Mvc.Razor;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWork.Abstract;
using RepositoryLayer.UnitOfWork.Concrete;
using CoreLayer.BaseEntities;
using RepositoryLayer.context;
using EntityLayer.WebApp.Entities;
using EntityLayer.WebApp.Entities.product;
using Serilog;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace Exc_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();  // Include both controllers and views
            builder.Services.AddRazorPages();

            builder.Services.LoadRepositoryLayerExtensions(builder.Configuration);
            builder.Services.LoadServiceLayerExtensions();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //public static void LoadServiceLayerExtensions(this IServiceCollection services)
            //{
            //    services.AddScoped<IProductService, ProductService>();

            //    Services.AddScoped<IBaseEntity, BaseEntity>();

            //    Services.AddScoped<IUnitOfWork, UnitOfWork>();

            //    Services.AddScoped<ICategoryService, CategoryServicInvalidOperationException: Unable to resolve service for type 'RepositoryLayer.UnitOfWork.Concrete.UnitOfWork' while attempting to activate 'ServiceLayer.Services.Concrete.ProductService'.e>();

            //    Services.AddScoped<IProductService, ProductService>();
            //}


            //builder.Services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBaseEntity, Product>(); 
            builder.Services.AddScoped<IBaseEntity, Category>();
            //builder.Services.AddScoped<IProductService, ProductService>();

            Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(builder.Configuration) // Read Serilog configuration from appsettings.json
                    .CreateLogger();

            builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.None);
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

#pragma warning disable ASP0014


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

                endpoint.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoint.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}
