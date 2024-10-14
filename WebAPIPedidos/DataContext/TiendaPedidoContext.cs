namespace WebAPITienda.DataContext
{
    //Context Dependency inversion
    public class TiendaPedidoContext : DbContext
    {
        public TiendaPedidoContext(DbContextOptions<TiendaPedidoContext> options) : base(options)
        {

        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProducto> PedidoProducto { get; set; }
        public DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
