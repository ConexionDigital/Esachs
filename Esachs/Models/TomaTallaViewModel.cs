using achsservicios.Entities;

namespace achsservicios.Models
{
    public class TomaTallaViewModel
    {
        public Funcionario Funcionario { get; set; }
        public ICollection<PrendasViewModel> Prendas { get; set; }
        public ICollection<DetPedidos> DetPedidos { get; set; }
    }
}
