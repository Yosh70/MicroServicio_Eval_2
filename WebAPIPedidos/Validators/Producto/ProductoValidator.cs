namespace WebAPITienda.Validators;

public class ProductoValidator : AbstractValidator<ProductoDto>
{
    public ProductoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Precio).NotEmpty().GreaterThan(0);
    }

}
