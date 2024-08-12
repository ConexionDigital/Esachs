using achsservicios.Entities;

namespace achsservicios.Models
{
    public class EditarFuncionarioViewModel
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public string Rut { get; set; }
        public string NombreCeco { get; set; }
        public string Nombres { get; set; }
        public string  Cargos { get; set; }
        public IEnumerable<Ceco> Cecos { get; set; }
    }
    
}
