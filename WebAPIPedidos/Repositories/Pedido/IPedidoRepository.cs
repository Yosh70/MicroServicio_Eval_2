namespace WebAPITienda.Repositories;

public interface IPedidoRepository
{
    Task<int> Create(PedidoAgregate pedido);
    Task<Pedido> Get(int id);
    Task<List<Pedido>> List();
    Task<Pedido> Update(Pedido pedido);
    Task<bool> Delete(int id);

    Task<List<PedidoProducto>> GetDetail(int id);

}
