using achsservicios.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class TallaConfig
    {
        public void Configure(EntityTypeBuilder<Talla> builder)
        {
            builder.Property(prop => prop.Descripcion)
                .HasMaxLength(5);
        }
    }
}
