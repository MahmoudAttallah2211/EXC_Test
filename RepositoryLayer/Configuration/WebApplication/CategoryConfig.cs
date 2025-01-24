using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityLayer.Identity.Entities;
using Microsoft.IdentityModel;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class CategoryConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(256);

            //builder.Property(x => x.Filename).IsRequired();

            //builder.Property(x => x.filetype).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);


            builder.HasData(new Product

            {
                Id = 1,

                Name = "First_Category",

                CreatedByUserId = "FirstOne",

                CreationDate = DateTime.Now,

                ImagePath = "/images/laptop.jpg"

            }, new Product

            {
                Id = 2,

                Name = "Second_Category",

                CreatedByUserId = "SecondOne",

                CreationDate = DateTime.Now,

                ImagePath = "/images/laptop.jpg"

            }, new Product

            {

                Id = 3,

                Name = "Third_Category",

                CreatedByUserId = "ThirdOne",

                CreationDate = DateTime.Now,

                ImagePath = "/images/laptop.jpg"
            }

            );


        }
    }
}
