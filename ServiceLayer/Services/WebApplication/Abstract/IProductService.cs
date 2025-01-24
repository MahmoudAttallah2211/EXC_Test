using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IProductService
    {
        Task<List<ProductListVM>> GetAllListAsync();

        Task AddproductyAsync(ProductUpdateVM request);

        Task DeleteproductAsync(int id);

        Task UpdateproductAsync(ProductUpdateVM request);

        Task<CategoryUpdateVM> GetproductById(int id);
        Task AddproductyAsync(ProductAddVM request);
        Task UpdateproductAsync(object request);
    }
}
