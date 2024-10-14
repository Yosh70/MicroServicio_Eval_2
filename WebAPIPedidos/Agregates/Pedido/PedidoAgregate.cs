namespace WebAPITienda.Agregates;

public class PedidoAgregate : Pedido
{
    //Fields
    readonly List<CreatePedidoProductoDto> createPedidoProductos = new List<CreatePedidoProductoDto>();

    //Properties
    public IReadOnlyCollection<CreatePedidoProductoDto> PedidoDetails => createPedidoProductos;


    public static PedidoAgregate From(CreatePedidoDto createPedidoDto)
    {
        PedidoAgregate pedido = new PedidoAgregate
        {
            Fecha = createPedidoDto.Fecha,
            ClienteId = createPedidoDto.ClienteId,
        };

        foreach (var Item in createPedidoDto.PedidoProducto)
        {
            pedido.createPedidoProductos.Add(new CreatePedidoProductoDto
            {
                ProductoId = Item.ProductoId,
                Cantidad = Item.Cantidad
            });
        }

        return pedido;
    }


}
