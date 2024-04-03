using FluentValidation;
using PharmaMVC.Models;

namespace PharmaMVC.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        // RuleFor(x => x.CategoryName)
        //     .NotEmpty().WithMessage("El nombre de la categoria no puede estar vacio")
        //     .MinimumLength(4).MaximumLength(20).WithMessage("El nombre debe tener entre 4 a 20 caracteres");
        // RuleFor(x => x.SubcategoryName)
        //     .NotEmpty().WithMessage("El nombre de la subcategoria no puede estar vacio")
        //     .MinimumLength(5).MaximumLength(15).WithMessage("El nombre debe tener entre 5 a 15 caracteres");
    }
}