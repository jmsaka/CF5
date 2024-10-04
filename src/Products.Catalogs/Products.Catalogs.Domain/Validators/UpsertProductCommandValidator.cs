namespace Products.Catalogs.Domain.Validators;

public class UpsertProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public UpsertProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
