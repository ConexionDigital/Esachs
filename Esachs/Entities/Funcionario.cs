using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace achsservicios.Entities
{
    public class Funcionario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rut { get; set; }
        public char Dv { get; set; }
        public string Nombre { get; set; }
        public char Sexo { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool TallaTomada { get; set; }
        public bool ParkaSolicitada { get; set; }
        public bool Estado { get; set; }
        public Ceco Ceco { get; set; }
        public Uniforme Uniforme { get; set; }
        public Cargo Cargo { get; set; }
    }
}
