using achsservicios.Entities;

namespace achsservicios.Models
{
    public class TallaSolicitadaViewModel
    {
        public ICollection<Prenda> Prendas { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
