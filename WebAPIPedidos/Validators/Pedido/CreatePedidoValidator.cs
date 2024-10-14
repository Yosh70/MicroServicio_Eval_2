namespace WebAPITienda.Validators.Pedido;

public class CreatePedidoValidator : AbstractValidator<CreatePedidoDto>
{
    public CreatePedidoValidator()
    {
        RuleFor(x => x.Fecha).NotEmpty();
        RuleFor(x => x.ClienteId).NotEmpty().GreaterThan(0);
        RuleForEach(x => x.PedidoProducto).SetValidator(new CreatePedidoProductoValidator());
    }
}
