using EntityLayer.WebApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.StartDate).IsRequired().HasMaxLength(256);
            builder.Property(x => x.CreatedByUserId).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(256);



            builder.HasData(new Product
            {
                Id = 1,

                Name = "First_Product",

                CategoryId = 1,

                Price = 250,

                CreatedByUserId = "FirstOne",

                ImagePath = "One"



            }, new Product

            {
                Id = 2,

                Name = "Second_Product",

                CategoryId = 2,

                Price = 300,

                CreatedByUserId = "SecondOne",

                ImagePath = "Two"


            }, new Product

            {
                Id = 3,

                Name = "Third_Product",

                CategoryId = 3,

                Price = 400,

                CreatedByUserId = "ThirdOne",

                ImagePath = "Three"

            }


            );
        }
    }
}
