namespace WebAPITienda.Dtos.Pedido;

public class UpdatePedidoHeadDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public List<UpdatePedidoDetailDto> PedidoProducto { get; set; }
}
