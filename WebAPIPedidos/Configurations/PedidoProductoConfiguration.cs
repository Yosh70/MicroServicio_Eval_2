namespace WebAPITienda.Configurations
{
    internal class PedidoProductoConfiguration : IEntityTypeConfiguration<PedidoProducto>
    {
        public void Configure(EntityTypeBuilder<PedidoProducto> builder)
        {
            builder.HasKey(x => new { x.PedidoId, x.ProductoId });

            builder.Property(x => x.Cantidad)
                .IsRequired();
        }
    }
}
