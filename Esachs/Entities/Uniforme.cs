using System.ComponentModel.DataAnnotations;

namespace achsservicios.Entities
{
    public class Uniforme
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
