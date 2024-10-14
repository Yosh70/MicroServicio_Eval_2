namespace WebAPITienda.Validators.Pedido;

public class CreatePedidoProductoValidator : AbstractValidator<CreatePedidoProductoDto>
{
    public CreatePedidoProductoValidator()
    {
        RuleFor(x => x.ProductoId).NotEmpty().GreaterThan(0);
        RuleFor(x => (int)x.Cantidad).NotEmpty().GreaterThan(0);
    }
}
