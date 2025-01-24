using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FluentValidation.AspNetCore;
using EntityLayer.WebApp.Entities;
using ServiceLayer.FluentValidation.WebApplication.ProductValidation;
using ServiceLayer.Services.Identity;

namespace ServiceLayer.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            services.LoadIdentityExtensions();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("services"));

            foreach (var serviseType in types)
            {
                var iServseType = serviseType.GetInterfaces().FirstOrDefault(x => x.Name == $"I{serviseType.Name}");

                if (iServseType!=null)
                {
                    services.AddScoped(iServseType,serviseType);
                }

            }

            services.AddFluentValidationAutoValidation(opt=>
                
                {
                    opt.DisableDataAnnotationsValidation = true;
            });

            services.AddValidatorsFromAssemblyContaining<ProductAddValidation>();

            return services;
        }
    }
}
