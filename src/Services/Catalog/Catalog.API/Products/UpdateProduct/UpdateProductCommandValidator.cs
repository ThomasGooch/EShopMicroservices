namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is REQUIRED.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is REQUIRED.");
            RuleFor(x => x.Categories).NotEmpty().WithMessage("Categories is REQUIRED.");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is REQUIRED.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
