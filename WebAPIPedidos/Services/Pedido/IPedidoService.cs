namespace WebAPITienda.Services;

public interface IPedidoService
{
    Task<int> Create(CreatePedidoDto pedido);
    Task<PedidoDto> Get(int id);
    Task<List<PedidoDto>> List();
    Task<UpdatePedidoDto> Update(int id, UpdatePedidoDto pedido);
    Task<bool> Delete(int id);

    Task<List<ResponsePedidoProductoDto>> GetDetail(int id);

}
