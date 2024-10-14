namespace WebAPITienda.Repositories;

public interface IProductoRepository
{
    Task<int> Create(Producto producto);
    Task<Producto> Get(int id);
    Task<List<Producto>> List();
    Task<Producto> Update(Producto producto);
    Task<bool> Delete(int id);
}
