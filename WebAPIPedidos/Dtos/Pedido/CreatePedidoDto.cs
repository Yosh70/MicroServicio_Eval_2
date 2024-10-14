namespace WebAPITienda.Dtos.Pedido;

public class CreatePedidoDto
{
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public List<CreatePedidoProductoDto> PedidoProducto { get; set; }
}
