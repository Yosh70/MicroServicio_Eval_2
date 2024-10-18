namespace WebAPITienda.Agregates;

public class PedidoAgregate : Pedido
{
    //Fields
    readonly List<CreatePedidoProductoDto> createPedidoProductos = new List<CreatePedidoProductoDto>();
    readonly List<UpdatePedidoDetailDto> updatePedidoDetailDtos = new List<UpdatePedidoDetailDto>();

    //Properties
    public IReadOnlyCollection<CreatePedidoProductoDto> PedidoDetails => createPedidoProductos;
    public IReadOnlyCollection<UpdatePedidoDetailDto> updatePedidoDetails => updatePedidoDetailDtos;


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


    public static PedidoAgregate FromUpdate(UpdatePedidoHeadDto updatePedidoHeadDto)
    {
        PedidoAgregate pedido = new PedidoAgregate
        {
            Id = updatePedidoHeadDto.Id,
            Fecha = updatePedidoHeadDto.Fecha,
            ClienteId = updatePedidoHeadDto.ClienteId,
        };

        foreach (var Item in updatePedidoHeadDto.PedidoProducto)
        {
            pedido.updatePedidoDetailDtos.Add(new UpdatePedidoDetailDto
            {
                PedidoId = Item.PedidoId,
                ProductoId = Item.ProductoId,
                Cantidad = Item.Cantidad
            });
        }

        return pedido;
    }


}
