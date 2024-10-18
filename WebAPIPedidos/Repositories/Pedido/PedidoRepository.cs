namespace WebAPITienda.Repositories;

public class PedidoRepository : IPedidoRepository
{
    //Field
    private readonly TiendaPedidoContext _tiendaPedidoContext;

    //Constructor
    public PedidoRepository(TiendaPedidoContext tiendaPedidoContext)
    {
        _tiendaPedidoContext = tiendaPedidoContext;
    }

    //Methods
    public async Task<int> Create(PedidoAgregate pedido)
    {

        await _tiendaPedidoContext.AddAsync(pedido);
        foreach (var item in pedido.PedidoDetails)
        {
            await _tiendaPedidoContext.AddAsync(new PedidoProducto
            {
                Pedido = pedido,
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad
            });
        }
        await SaveChanges();
        return pedido.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var removePedido = await _tiendaPedidoContext.Pedido
                                .Include(x => x.PedidoProductos)
                                .FirstOrDefaultAsync(x => x.Id == id);

        if (removePedido is null || removePedido.PedidoProductos.Any()) return false;

        _tiendaPedidoContext.Remove(removePedido);
        await SaveChanges();
        return true;
    }

    public async Task<Pedido> Get(int id) =>
        await _tiendaPedidoContext.Pedido.Include(x => x.PedidoProductos)
                                         .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Pedido>> List() =>
        await _tiendaPedidoContext.Pedido.Include(x => x.PedidoProductos)
                                         .ToListAsync();

    public async Task<Pedido> Update(Pedido pedido)
    {
        var oldPedido = await _tiendaPedidoContext.Producto
                                    .AnyAsync(x => x.Id == pedido.Id);

        if (!oldPedido) return null;

        _tiendaPedidoContext.Update(pedido);
        await SaveChanges();

        return pedido;
    }

    public async Task<List<PedidoProducto>> GetDetail(int id) =>
        await _tiendaPedidoContext.PedidoProducto.Include(x => x.Producto).ToListAsync();


    public async Task<Pedido> UpdateDetail(PedidoAgregate pedido)
    {
        var existPedido = await _tiendaPedidoContext.Pedido
                                 .Include(x => x.PedidoProductos)
                                 .FirstOrDefaultAsync(x => x.Id == pedido.Id);

        if (existPedido is null) return null;

        if (existPedido.PedidoProductos.Any())
        {
            _tiendaPedidoContext.RemoveRange(existPedido.PedidoProductos);
            await SaveChanges();

            foreach (var item in pedido.updatePedidoDetails)
            {
                await _tiendaPedidoContext.AddAsync(new PedidoProducto
                {
                    Pedido = existPedido,
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad
                });
            }
            await SaveChanges();
        }

        return existPedido;
    }


    public async Task SaveChanges() =>
        await _tiendaPedidoContext.SaveChangesAsync();

}
