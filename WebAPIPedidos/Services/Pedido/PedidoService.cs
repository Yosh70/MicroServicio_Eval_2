namespace WebAPITienda.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<int> Create(CreatePedidoDto createPedidoDto)
    {

        PedidoAgregate pedidoAgregate = PedidoAgregate.From(createPedidoDto);
        await _pedidoRepository.Create(pedidoAgregate);

        return pedidoAgregate.Id;
    }

    public async Task<bool> Delete(int id) =>
        await _pedidoRepository.Delete(id);

    public async Task<PedidoDto> Get(int id)
    {
        var pedido = await _pedidoRepository.Get(id);

        if (pedido is null) return null;

        PedidoDto pedidoDto = new PedidoDto()
        {
            Id = pedido.Id,
            Fecha = pedido.Fecha,
            ClienteId = pedido.ClienteId
        };

        foreach (var item in pedido.PedidoProductos)
        {
            pedidoDto.PedidoProducto.Add(new PedidoProductoDto
            {
                PedidoId = item.PedidoId,
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad
            });
        }

        return pedidoDto;
    }

    public async Task<List<PedidoDto>> List()
    {
        var pedidos = await _pedidoRepository.List();

        if (!pedidos.Any()) return null;

        List<PedidoDto> pedidoDtoList = new();

        foreach (var pedido in pedidos)
        {
            PedidoDto pedidoDto = new PedidoDto()
            {
                Id = pedido.Id,
                Fecha = pedido.Fecha,
                ClienteId = pedido.ClienteId
            };

            foreach (var item in pedido.PedidoProductos)
            {
                pedidoDto.PedidoProducto.Add(new PedidoProductoDto
                {
                    PedidoId = item.PedidoId,
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad
                });
            }

            pedidoDtoList.Add(pedidoDto);
        }

        return pedidoDtoList;

    }

    public async Task<UpdatePedidoDto> Update(int id, UpdatePedidoDto pedido)
    {
        if (id != pedido.Id) return null;

        Pedido newPedido = new()
        {
            Id = id,
            Fecha = pedido.Fecha,
            ClienteId = pedido.ClienteId
        };

        var updatePedido = await _pedidoRepository.Update(newPedido);

        return updatePedido is null ? null : new UpdatePedidoDto
        {
            Id = updatePedido.Id,
            Fecha = updatePedido.Fecha,
            ClienteId = updatePedido.ClienteId
        };
    }

    public async Task<List<ResponsePedidoProductoDto>> GetDetail(int id)
    {
        var pedido = await _pedidoRepository.GetDetail(id);

        if (pedido is null) return null;

        List<ResponsePedidoProductoDto> pedidoDetail = new();

        foreach (var item in pedido)
        {
            pedidoDetail.Add(new ResponsePedidoProductoDto
            {
                PedidoId = item.PedidoId,
                ProductoId = item.ProductoId,
                ProductoNombre = item.Producto.Nombre,
                Cantidad = item.Cantidad
            });
        }

        return pedidoDetail;
    }

    public async Task<UpdatePedidoHeadDto> UpdateDetail(int id, UpdatePedidoHeadDto pedido)
    {
        if (id != pedido.Id) return null;

        PedidoAgregate pedidoAgregate = PedidoAgregate.FromUpdate(pedido);

        var updatePedido = await _pedidoRepository.UpdateDetail(pedidoAgregate);

        if (updatePedido is null) return null;

        UpdatePedidoHeadDto updatePedidoHeadDto = new()
        {
            Id = updatePedido.Id,
            Fecha = updatePedido.Fecha,
            ClienteId = updatePedido.ClienteId
        };

        foreach (var item in updatePedido.PedidoProductos)
        {
            updatePedidoHeadDto.PedidoProducto.Add(new UpdatePedidoDetailDto
            {
                PedidoId = item.PedidoId,
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad
            });
        }

        return updatePedidoHeadDto;

    }
}
