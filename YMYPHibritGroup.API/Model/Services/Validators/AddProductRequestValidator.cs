using FluentValidation;
using YMYPHibrit3Group.API.Model.Repositories;
using YMYPHibrit3Group.API.Model.Services.Dto;

namespace YMYPHibrit3Group.API.Model.Services.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            //fluent API syntax approach
            RuleFor(x => x.Name).Length(5, 20).WithMessage("Name must be between 5 and 20 characters");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stock must be greater than 0");

            //RuleFor(x => x.Name).Must(x => x.StartsWith("A")).WithMessage("Ürün ismi A harfi başlamalıdır");

            RuleFor(x => x.Name).Must(MustBeStartWithAChar).WithMessage("Ürün ismi A harfi başlamalıdır");
        }

        public bool MustBeStartWithAChar(string name)
        {
            return name.StartsWith("A");
        }
    }
}