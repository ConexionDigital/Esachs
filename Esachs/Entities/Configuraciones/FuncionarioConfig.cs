using achsservicios.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class FuncionarioConfig
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(70);
        }
    }
}
