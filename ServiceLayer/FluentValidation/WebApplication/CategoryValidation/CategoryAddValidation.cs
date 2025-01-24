using EntityLayer.WebApp.ViewModels.Category;
using EntityLayer.WebApp.ViewModels.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddVM>
    {
        public CategoryAddValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            ;

            RuleFor(x => x.Price)
            .NotEmpty()
            .NotNull()
            ;

            RuleFor(x => x.Duration)
            .NotEmpty()
            .NotNull()
            ;

            RuleFor(x => x.CreationDate)
            .NotEmpty()
            .NotNull()
            ;


            RuleFor(x => x.ImagePath)
            .NotEmpty()
            .NotNull()
            ;

            RuleFor(x => x.CreatedByUserId)
            .NotEmpty()
            .NotNull()
            ;
            ;
        }
    }
}
