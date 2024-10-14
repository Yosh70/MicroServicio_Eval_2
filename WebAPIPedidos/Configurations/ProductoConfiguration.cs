namespace WebAPITienda.Configurations
{
    internal class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(x => x.Nombre)
                .IsRequired();

            builder.Property(x => x.Precio)
                .IsRequired()
                .HasPrecision(8, 2);
        }
    }
}
