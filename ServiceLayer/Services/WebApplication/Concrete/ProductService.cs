using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.BaseEntities;
using EntityLayer.WebApp.Entities;
using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IBaseEntity _baseEntity;

        private readonly IMapper _mapper;

        private readonly IGenericRepositories<Product> _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IBaseEntity baseEntity)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _baseEntity = baseEntity;

            _productRepository = _unitOfWork.GetGenericRepository<Product>();
        }

        [HttpPost("AddEntityAsync")]
        public async Task<List<ProductListVM>> GetAllListAsync()
        {
            var productListVM = await _productRepository.GetAllListAsync().ProjectTo<ProductListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return productListVM;

        }
        //[HttpPost("AddEntityAsync")]
        //public async Task AddEntityAsync(ProducAddVM request)
        //{
        //    var product = _mapper.Map<Product>(request);

        //    await _productRepository.AddEntityAsync(product);

        //    await _unitOfWork.CommitAsync();

        //}
        [HttpDelete("DeleteEntityAsync")]
        public async Task DeleteproductAsync(int id)
        {
            var product = await _productRepository.GetEntityByIDAsync(id);

            _productRepository.DeleteEntity(product);

            await _unitOfWork.CommitAsync();

        }
        //public async Task<CategoryUpdateVM> GetCategoryById(int id)
        //{
        //    var category = await _repository.where(x => x.Id == id).ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();

        //    await category;

        //}
        [HttpPut("UpdateproductAsync")]
        public async Task UpdateproductAsync(ProductUpdateVM request)
        {
            var product = _mapper.Map<Product>(request);

            _productRepository.UpdateEntity(product);

            await _unitOfWork.CommitAsync();

        }

        //public Task AddcategoryAsync(ProductUpdateVM request)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<CategoryUpdateVM> GetproductById(int id)
        {
            throw new NotImplementedException();
        }

        Task IProductService.AddproductyAsync(ProductUpdateVM request)
        {
            throw new NotImplementedException();
        }

        public Task AddproductyAsync(ProductAddVM request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateproductAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}

