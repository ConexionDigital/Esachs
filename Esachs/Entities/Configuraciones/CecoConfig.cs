using achsservicios.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class CecoConfig
    {
        public void Configure(EntityTypeBuilder<Ceco> builder)
        {
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(70);
            builder.Property(prop => prop.Direccion)
                .HasMaxLength(100);
            builder.Property(prop => prop.Responsable)
                .HasMaxLength(100);
        }
    }
}
