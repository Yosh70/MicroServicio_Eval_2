namespace WebAPITienda.Dtos.Pedido;

public class PedidoDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public List<PedidoProductoDto> PedidoProducto { get; set; } = new List<PedidoProductoDto>();
}
