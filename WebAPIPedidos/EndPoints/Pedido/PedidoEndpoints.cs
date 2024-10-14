namespace WebAPITienda.EndPoints;

public static class PedidoEndpoints
{
    public static void UsePedidoEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var pedido = endpointRouteBuilder.MapGroup("/pedido").WithTags("Pedido");

        pedido.MapGet("/{id}", async ([FromRoute] int id, IPedidoService service)
                                => await service.Get(id) is PedidoDto pedido
                                ? Results.Ok(pedido)
                                : Results.BadRequest(new { Error = "Error getting pedido" }))
            .WithSummary("Get Pedido by Id")
            .Produces<PedidoDto>(statusCode: 200, contentType: "application/json");


        pedido.MapGet("", async (IPedidoService service)
                                => Results.Ok(await service.List()))
            .WithSummary("Get List Pedidos")
            .Produces<List<PedidoDto>>(statusCode: 200, contentType: "application/json");


        pedido.MapPost("", async ([FromBody] CreatePedidoDto createPedidoDto,
                                    IPedidoService service)
                                => await service.Create(createPedidoDto) is int pedidoId
                                ? Results.Ok(pedidoId)
                                : Results.BadRequest(new { Error = "Error creating pedido" }))
            .WithSummary("Create new Pedido")
            .Produces<int>(statusCode: 200)
            .AddEndpointFilter<ValidationFilter<CreatePedidoDto>>()
            .WithRequestValidation<CreatePedidoDto>();


        pedido.MapPut("/{id}", async ([FromRoute] int id,
                                        [FromBody] UpdatePedidoDto createPedidoDto,
                                        IPedidoService service)
                                => await service.Update(id, createPedidoDto)
                                            is UpdatePedidoDto pedido
                                            ? Results.Ok(pedido)
                                            : Results.BadRequest("Error updating pedido"))
            .WithSummary("Update Pedido by Id")
            .Produces<UpdatePedidoDto>(statusCode: 200, contentType: "application/json")
            .AddEndpointFilter<ValidationFilter<UpdatePedidoDto>>()
            .WithRequestValidation<UpdatePedidoDto>();


        pedido.MapDelete("/{id}", async ([FromRoute] int id, IPedidoService service)
                                => await service.Delete(id) is bool pedidoDelete
                                ? Results.Ok(pedidoDelete)
                                : Results.NotFound(new { Error = "Error deleting pedido" }))
            .WithSummary("Delete Pedido by Id")
            .Produces<bool>(statusCode: 200, contentType: "application/json");


        pedido.MapGet("/{id}/productos", async ([FromRoute] int id, IPedidoService service)
                                => await service.GetDetail(id) is List<ResponsePedidoProductoDto> pedidoDetail
                                ? Results.Ok(pedidoDetail)
                                : Results.BadRequest(new { Error = "Error getting pedido productos" }))
            .WithSummary("Get Productos by Pedido Id")
            .Produces<ResponsePedidoProductoDto>(statusCode: 200, contentType: "application/json");

    }
}
