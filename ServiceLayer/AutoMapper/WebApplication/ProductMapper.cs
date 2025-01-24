using AutoMapper;
using EntityLayer.WebApp.Entities;
using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper.WebApplication
{
    public class ProductMapper : Profile
    {

        public ProductMapper()
        {
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
            CreateMap<Product, ProductListVM>().ReverseMap();
            CreateMap<Product, ProductUpdateVM>().ReverseMap();
        }
    }
}
