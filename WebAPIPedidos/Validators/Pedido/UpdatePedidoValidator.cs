namespace WebAPITienda.Validators.Pedido;

public class UpdatePedidoValidator : AbstractValidator<UpdatePedidoDto>
{
    public UpdatePedidoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Fecha).NotEmpty();
        RuleFor(x => x.ClienteId).NotEmpty().GreaterThan(0);
    }

}
