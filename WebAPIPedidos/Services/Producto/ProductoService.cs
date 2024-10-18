namespace WebAPITienda.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;
    private readonly ILogger<ProductoService> _logger;

    public ProductoService(IProductoRepository productoRepository,
                           ILogger<ProductoService> logger)
    {
        _productoRepository = productoRepository;
        _logger = logger;
    }

    public async Task<int> Create(CreateProductoDto productoDto)
    {
        _logger.LogInformation($"Application: Request: {JsonSerializer.Serialize(productoDto)}\n");

        Producto producto = new()
        {
            Nombre = productoDto.Nombre,
            Precio = productoDto.Precio
        };

        await _productoRepository.Create(producto);

        return producto.Id;
    }

    public async Task<bool> Delete(int id) =>
        await _productoRepository.Delete(id);


    public async Task<ProductoDto> Get(int id)
    {
        var producto = await _productoRepository.Get(id);

        return producto is null ? null : new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio
        };

    }

    public async Task<List<ProductoDto>> List()
    {
        var productosList = await _productoRepository.List();
        return productosList is null ? null : productosList.Select(x => new ProductoDto
        {
            Id = x.Id,
            Nombre = x.Nombre,
            Precio = x.Precio
        }).ToList();
    }

    public async Task<ProductoDto> Update(int id, ProductoDto productoDto)
    {
        if (id != productoDto.Id) return null;

        Producto newProducto = new()
        {
            Id = id,
            Nombre = productoDto.Nombre,
            Precio = productoDto.Precio
        };

        var updateProducto = await _productoRepository.Update(newProducto);

        return updateProducto is null ? null : new ProductoDto
        {
            Id = updateProducto.Id,
            Nombre = updateProducto.Nombre,
            Precio = updateProducto.Precio
        };

    }
}
