namespace WebAPITienda.Dtos.Pedido;

public class ResponsePedidoProductoDto
{
    public int PedidoId { get; set; }
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; }
    public short Cantidad { get; set; }
}
