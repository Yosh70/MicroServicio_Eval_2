namespace WebAPITienda.Validators.Pedido;

public class UpdatePedidoHeadValidator : AbstractValidator<UpdatePedidoHeadDto>
{
    public UpdatePedidoHeadValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Fecha).NotEmpty();
        RuleFor(x => x.ClienteId).NotEmpty().GreaterThan(0);
        RuleForEach(x => x.PedidoProducto).SetValidator(new UpdatePedidoDetailValidator());
    }

}
