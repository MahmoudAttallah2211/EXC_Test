using EntityLayer.Identity.Entities;
using EntityLayer.WebApp.Entities;
using EntityLayer.WebApp.Entities.product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        {


        }

        public AppDbContext()
        {

        }

        public DbSet<Product> Products {get;set;}

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Product>().Property(x => x.Id).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Category>().Property(x => x.Id).IsRequired().HasMaxLength(150);

            base.OnModelCreating(modelBuilder);
        }



    }
}
