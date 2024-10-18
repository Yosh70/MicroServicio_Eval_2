namespace WebAPITienda.Validators.Pedido;

public class UpdatePedidoDetailValidator : AbstractValidator<UpdatePedidoDetailDto>
{
    public UpdatePedidoDetailValidator()
    {
        RuleFor(x => x.PedidoId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.ProductoId).NotEmpty().GreaterThan(0);
        RuleFor(x => (int)x.Cantidad).NotEmpty().GreaterThan(0);
    }
}
