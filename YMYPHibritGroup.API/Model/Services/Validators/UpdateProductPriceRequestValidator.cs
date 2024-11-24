using FluentValidation;
using YMYPHibrit3Group.API.Model.Services.Dto;

namespace YMYPHibrit3Group.API.Model.Services.Validators
{
    public class UpdateProductPriceRequestValidator : AbstractValidator<UpdateProductPriceRequest>
    {
        public UpdateProductPriceRequestValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}