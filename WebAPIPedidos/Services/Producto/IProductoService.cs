namespace WebAPITienda.Services;

public interface IProductoService
{
    Task<int> Create(CreateProductoDto producto);
    Task<ProductoDto> Get(int id);
    Task<List<ProductoDto>> List();
    Task<ProductoDto> Update(int id, ProductoDto productoDto);
    Task<bool> Delete(int id);
}
