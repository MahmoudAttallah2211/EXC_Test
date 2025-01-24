using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListVM>> GetAllListAsync();
        Task AddcategoryAsync(CategoryAddVM request);

        Task deletecategoryAsync(int id);

        Task updatecategoryAsync(CategoryAddVM request);

        Task<CategoryUpdateVM> GetCategoryById(int id);
        Task AddcategoryAsync(ProductAddVM request);
        Task updatecategoryAsync(CategoryUpdateVM request);
        Task updatecategoryAsync(ProductUpdateVM request);
    }
}
