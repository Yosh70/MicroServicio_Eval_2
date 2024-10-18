namespace WebAPITienda.Dtos.Pedido;

public class UpdatePedidoDetailDto
{
    public int PedidoId { get; set; }
    public int ProductoId { get; set; }
    public short Cantidad { get; set; }
}
