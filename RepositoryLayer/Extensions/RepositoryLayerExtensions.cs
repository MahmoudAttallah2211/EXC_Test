using CoreLayer.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.context;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWork.Abstract;
using RepositoryLayer.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Extensions
{
    public static class RepositoryLayerExtensions
    {
        public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString: Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));

            services.AddScoped<DbContext, AppDbContext>();

            //services.AddScoped<IBaseEntity, BaseEntity>();



            //services.AddScoped<UnitOfWork>();

            //services.AddScoped<IUnitOfWork>();



            return services;

        }
    }
}
