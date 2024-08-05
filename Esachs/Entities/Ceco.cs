using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace achsservicios.Entities
{
    public class Ceco
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public int CONT_ID { get; set; }
        public int REG_ID { get; set; }
        public int COM_ID { get; set; }
        public HashSet<Funcionario> Funcionario { get; set; }
    }
}
