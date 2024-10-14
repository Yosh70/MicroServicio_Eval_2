namespace WebAPITienda;

public static class DependencyContainer
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        // Add NLog as the logger provider
        //services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();

        services.AddDbContext<TiendaPedidoContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("AUTOCOMDB"))
            );


        services.AddScoped<IPedidoService, PedidoService>();
        services.AddScoped<IProductoService, ProductoService>();

        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();


        return services;
    }

}
