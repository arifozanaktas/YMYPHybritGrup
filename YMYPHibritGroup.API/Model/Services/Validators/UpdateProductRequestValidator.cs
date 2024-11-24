using FluentValidation;
using YMYPHibrit3Group.API.Model.Services.Dto;

namespace YMYPHibrit3Group.API.Model.Services.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name).Length(5, 20).WithMessage("Name must be between 5 and 20 characters");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}