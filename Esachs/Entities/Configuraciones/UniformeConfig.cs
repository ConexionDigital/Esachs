using achsservicios.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class UniformeConfig
    {
        public void Configure(EntityTypeBuilder<Uniforme> builder)
        {
            builder.Property(prop => prop.Descripcion)
                .HasMaxLength(30);
        }
    }
}
