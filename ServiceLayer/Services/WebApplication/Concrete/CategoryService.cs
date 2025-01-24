using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using EntityLayer.WebApp.Entities;
using EntityLayer.WebApp.Entities.product;
using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.HomePage;
using EntityLayer.WebApp.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWork.Abstract;
using RepositoryLayer.UnitOfWork.Concrete;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IGenericRepositories<Product> _productRepository;

        private readonly IGenericRepositories<Category> _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _productRepository = _unitOfWork.GetGenericRepository<Product>();
            _categoryRepository = _unitOfWork.GetGenericRepository<Category>();
        }


        //public async Task<List<CategoryListVM>> GetAllListAsync()
        //{
        //    var categoryListVM = await _categoryRepository.GetAllListAsync().ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).ToListAsync();

        //    return categoryListVM;

        //}

        public async Task AddcategoryAsync(CategoryAddVM request)
        {
            var category = _mapper.Map<Category>(request);

            await _categoryRepository.AddEntityAsync(category);

            await _unitOfWork.CommitAsync();

        }

        public async Task deletecategoryAsync(int id)
        {
            var category = await _categoryRepository.GetEntityByIDAsync(id);

            _categoryRepository.DeleteEntity(category);

            await _unitOfWork.CommitAsync();

        }
        //public async Task<CategoryUpdateVM> GetCategoryById(int id)
        //{
        //    var category = await _repository.where(x => x.Id == id).ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();

        //    await category;

        //}

        public async Task updatecategoryAsync(CategoryAddVM request)
        {
            var category = _mapper.Map<Category>(request);

            _categoryRepository.UpdateEntity(category);

            await _unitOfWork.CommitAsync();

        }

        public Task<CategoryUpdateVM> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<CategoryListVM>> ICategoryService.GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        Task ICategoryService.AddcategoryAsync(ProductAddVM request)
        {
            throw new NotImplementedException();
        }

        Task ICategoryService.updatecategoryAsync(CategoryUpdateVM request)
        {
            throw new NotImplementedException();
        }

        Task ICategoryService.updatecategoryAsync(ProductUpdateVM request)
        {
            throw new NotImplementedException();
        }
    }
}
