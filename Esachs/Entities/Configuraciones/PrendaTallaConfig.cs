using achsservicios.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class PrendaTallaConfig : IEntityTypeConfiguration<PrendaTalla>
    {
        public void Configure(EntityTypeBuilder<PrendaTalla> builder)
        {
            builder.HasKey(prop => new
            {
                prop.PrendaId,
                prop.TallaId
            });

        }
    }
}
