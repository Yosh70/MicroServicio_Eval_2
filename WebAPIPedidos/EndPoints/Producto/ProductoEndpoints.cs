namespace WebAPITienda.EndPoints;

public static class ProductoEndpoints
{
    public static void UseProductoEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var producto = endpointRouteBuilder.MapGroup("/producto").WithTags("Producto");

        producto.MapGet("/{id}", async ([FromRoute] int id, IProductoService service)
                                => await service.Get(id) is ProductoDto producto
                                ? Results.Ok(producto)
                                : Results.BadRequest(new { Error = "Error getting producto" }))
            .WithSummary("Get Producto by Id")
            .Produces<ProductoDto>(statusCode: 200, contentType: "application/json");


        producto.MapGet("", async (IProductoService service)
                                => Results.Ok(await service.List()))
            .WithSummary("Get List Productos")
            .Produces<List<ProductoDto>>(statusCode: 200, contentType: "application/json");


        producto.MapPost("", async ([FromBody] CreateProductoDto createProductoDto,
                                    IProductoService service)
                                => Results.Ok(await service.Create(createProductoDto)))
            .WithSummary("Create new Producto")
            .Produces<int>(statusCode: 200)
            .AddEndpointFilter<ValidationFilter<CreateProductoDto>>()
            .WithRequestValidation<CreateProductoDto>();


        producto.MapPut("/{id}", async ([FromRoute] int id,
                                        [FromBody] ProductoDto createProductoDto,
                                        IProductoService service)
                                => await service.Update(id, createProductoDto)
                                            is ProductoDto producto
                                            ? Results.Ok(producto)
                                            : Results.BadRequest("Error updating producto"))
            .WithSummary("Update Producto by Id")
            .Produces<ProductoDto>(statusCode: 200, contentType: "application/json")
            .AddEndpointFilter<ValidationFilter<ProductoDto>>()
            .WithRequestValidation<ProductoDto>();


        producto.MapDelete("/{id}", async ([FromRoute] int id, IProductoService service)
                                => await service.Delete(id) is bool productoDelete
                                ? Results.Ok(productoDelete)
                                : Results.NotFound(new { Error = "Error deleting producto" }))
            .WithSummary("Delete Producto by Id")
            .Produces<bool>(statusCode: 200, contentType: "application/json");

    }

}
