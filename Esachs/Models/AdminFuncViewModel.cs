using achsservicios.Entities;

namespace achsservicios.Models
{
    public class AdminFuncViewModel
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public IEnumerable<Uniforme> Uniformes { get; set; }
    }
}
