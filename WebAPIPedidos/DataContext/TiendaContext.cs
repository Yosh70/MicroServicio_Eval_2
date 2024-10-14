namespace WebAPITienda.DataContext
{
    //Context Migrations
    internal class TiendaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("AUTOCOMDB");
            optionsBuilder.UseSqlServer(connectionString);
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
