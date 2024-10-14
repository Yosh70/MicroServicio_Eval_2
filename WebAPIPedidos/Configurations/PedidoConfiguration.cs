namespace WebAPITienda.Configurations
{
    internal class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(x => x.Fecha)
                .IsRequired();

            builder.HasMany(x => x.PedidoProductos)
                .WithOne(x => x.Pedido).HasPrincipalKey(x => new { x.Id })
                .HasForeignKey(x => new { x.PedidoId })
                .IsRequired();

            builder.Property(x => x.ClienteId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();

        }
    }
}
