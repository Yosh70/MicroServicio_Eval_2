namespace WebAPITienda.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int ClienteId { get; set; }
    public ICollection<PedidoProducto> PedidoProductos { get; set; }
}
