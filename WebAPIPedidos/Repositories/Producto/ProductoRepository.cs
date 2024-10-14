namespace WebAPITienda.Repositories;

public class ProductoRepository : IProductoRepository
{
    //Field
    private readonly TiendaPedidoContext _tiendaPedidoContext;

    //Constructor
    public ProductoRepository(TiendaPedidoContext tiendaPedidoContext)
    {
        _tiendaPedidoContext = tiendaPedidoContext;
    }

    //Methods
    public async Task<int> Create(Producto producto)
    {
        await _tiendaPedidoContext.AddAsync(producto);
        await SaveChanges();
        return producto.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var removeProducto = await _tiendaPedidoContext.Producto
                                .FirstOrDefaultAsync(x => x.Id == id);

        if (removeProducto is null) return false;

        _tiendaPedidoContext.Remove(removeProducto);
        await SaveChanges();
        return true;
    }

    public async Task<Producto> Get(int id) =>
        await _tiendaPedidoContext.Producto.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Producto>> List() =>
         await _tiendaPedidoContext.Producto.ToListAsync();

    public async Task<Producto> Update(Producto producto)
    {
        var oldProducto = await _tiendaPedidoContext.Producto
                                    .AnyAsync(x => x.Id == producto.Id);

        if (!oldProducto) return null;

        _tiendaPedidoContext.Update(producto);
        await SaveChanges();

        return producto;
    }

    public async Task SaveChanges() =>
        await _tiendaPedidoContext.SaveChangesAsync();

}
