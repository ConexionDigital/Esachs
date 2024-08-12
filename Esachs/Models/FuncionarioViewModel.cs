using achsservicios.Entities;

namespace achsservicios.Models
{
    public class FuncionarioViewModel
    {
        public Funcionario funcionario { get; set; }

        public IEnumerable<Cargo> cargo { get; set; }

        public IEnumerable<Uniforme> uniforme { get; set; }
        public IEnumerable <Ceco> ceco { get; set; }  
    }
} 
