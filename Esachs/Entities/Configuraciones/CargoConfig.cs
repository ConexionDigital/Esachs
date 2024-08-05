﻿using achsservicios.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace achsservicios.Entities.Configuraciones
{
    public class CargoConfig
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.Property(prop => prop.Nombre)
                .HasMaxLength(20);
        }
    }
}
