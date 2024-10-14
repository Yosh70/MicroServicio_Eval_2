namespace WebAPITienda.Validators;

public class CreateProductoValidator : AbstractValidator<CreateProductoDto>
{
    public CreateProductoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Precio).NotEmpty().GreaterThan(0);
    }
}
