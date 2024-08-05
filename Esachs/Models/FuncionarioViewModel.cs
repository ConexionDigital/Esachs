using achsservicios.Entities;

namespace achsservicios.Models
{
    public class FuncionarioViewModel
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string NombreCeco { get; set; }
        public IEnumerable<Prenda> Prendas { get; set; }
    }
}
