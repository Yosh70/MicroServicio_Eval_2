namespace WebAPITienda.Validators.Pedido;

public class PedidoValidator : AbstractValidator<PedidoDto>
{
    public PedidoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Fecha).NotEmpty();
        RuleFor(x => x.ClienteId).NotEmpty().GreaterThan(0);
    }

}
