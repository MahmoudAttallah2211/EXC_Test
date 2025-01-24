using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.Product;
using FluentValidation;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace Exc_Test.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly IValidator<CategoryAddVM> _AddValidator;
        private readonly IValidator<CategoryUpdateVM> _updateValidator;
        private readonly CategoryUpdateVM? _request;
        private readonly CategoryUpdateVM? request;
        public CategoryController(ICategoryService categoryService, IValidator<CategoryAddVM> addValidator, IValidator<CategoryUpdateVM> updateValidator)
        {
            _categoryService = categoryService;
            _AddValidator = addValidator;
            _updateValidator = updateValidator;
            _request = request;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetcategoryAsync()
        {
            var productlist = await _categoryService.GetAllListAsync();

            return View(productlist);
        }


        [HttpGet]
        public async Task<IActionResult> Addcategory(CategoryAddVM request)
        {
            var validation = await _AddValidator.ValidateAsync((IValidationContext)request);

            if (validation.IsValid)
            {

                await _categoryService.AddcategoryAsync(request);
                return RedirectToAction("GetAllList", "CategoryController", new { Area = ("Admin") });

            }


            return View(request);

        }


        [HttpGet]
        public async Task<IActionResult> Updatecategory(int id)
        {
            var validation = await _updateValidator.ValidateAsync(request);

            if (validation.IsValid)
            {

                await _categoryService.updatecategoryAsync(request);
                return RedirectToAction("GetAllList", "CategoryController", new { Area = ("Admin") });
            }

            return View(request);
        }


        [HttpPost]
        public async Task<IActionResult> Updatecategory(ProductUpdateVM request)
        {
            await _categoryService.updatecategoryAsync(request);

            return RedirectToAction("GetAllList", "CategoryController", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _categoryService.deletecategoryAsync(id);

            return RedirectToAction("GetAllList", "CategoryController", new { Area = ("Admin") });
        }
    }
}
