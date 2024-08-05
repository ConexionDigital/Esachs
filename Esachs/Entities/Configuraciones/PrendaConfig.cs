using achsservicios.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class PrendaConfig
    {
        public void Configure(EntityTypeBuilder<Prenda> builder)
        {
            builder.Property(prop => prop.Descripcion)
                .HasMaxLength(50);
        }
    }
}
