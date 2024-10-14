namespace WebAPITienda.Dtos.Pedido;

public class UpdatePedidoDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
}
