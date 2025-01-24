using Azure.Core;
using EntityLayer.WebApp.ViewModels.Product;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using ServiceLayer.Services.WebApplication.Abstract;

namespace Exc_Test.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {

        private readonly IProductService _productservice;

        private readonly IValidator<ProductAddVM> _AddValidator;
        private readonly IValidator<ProductUpdateVM> _updateValidator;
        private readonly ProductUpdateVM ?_request;
        private readonly ProductUpdateVM? request;

        public ProductController(IProductService productservice, IValidator<ProductAddVM> addValidator, IValidator<ProductUpdateVM> updateValidator)
        {
            _productservice = productservice;
            _AddValidator = addValidator;
            _updateValidator = updateValidator;
            _request = request;
        }

        public async Task <IActionResult> GetProductAsync()
        {
            var productlist = await _productservice.GetAllListAsync();

            return View(productlist);
        }


        [HttpGet]
        public  async Task<IActionResult> Addproduct(ProductAddVM request)
        {
            var validation = await _AddValidator.ValidateAsync(request);

           if (validation.IsValid)
            {

                await _productservice.AddproductyAsync(request);
                return RedirectToAction("GetAllList", "ProductController", new { Area = ("Admin") });

            }

           
            return View(request);
            
        }

        [HttpPost]
        //public async Task<IActionResult> Addproduct(ProductAddVM request)
        //{
        //    await _productservice.AddproductyAsync(request);

        //    return RedirectToAction("GetAllListAsync", "ProductController", new { Area = ("Admin") });
        //}


        [HttpGet]
        public async Task<IActionResult> Updateproduct(int id)
        {
            var validation = await _updateValidator.ValidateAsync(request);

            if (validation.IsValid)
            {

                await _productservice.UpdateproductAsync(request);
                return RedirectToAction("GetAllList", "ProductController", new { Area = ("Admin") });
            }

            return View(request);
        }


        [HttpPost]
        public async Task<IActionResult> updateproduct(ProductUpdateVM request)
        {
            await _productservice.UpdateproductAsync(request);

            return RedirectToAction("GetAllList", "ProductController", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
          await _productservice.DeleteproductAsync(id);

            return RedirectToAction("GetAllList", "ProductController", new { Area = ("Admin") });
        }
    }
}
