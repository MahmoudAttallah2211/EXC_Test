using AutoMapper;
using EntityLayer.WebApp.Entities;
using EntityLayer.WebApp.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AutoMapper.WebApplication
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Product, CategoryAddVM>().ReverseMap();
            CreateMap<Product, CategoryListVM>().ReverseMap();
            CreateMap<Product, CategoryUpdateVM>().ReverseMap();
        }
    }
}
