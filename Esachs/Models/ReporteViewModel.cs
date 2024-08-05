using achsservicios.Entities;

namespace achsservicios.Models
{
    public class ReporteViewModel
    {
        public int TallasTomadas { get; set; }
        public int FuncionariosTotales { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}
