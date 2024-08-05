using achsservicios.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace achsservicios
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Prenda> Prendas { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<Uniforme> Uniformes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PrendaTalla> PrendasTallas { get; set; }
        public DbSet<CabPedidos> CabPedidos { get; set; }
        public DbSet<DetPedidos> DetPedidos { get; set; }
    }
}
