using System.ComponentModel.DataAnnotations;

namespace achsservicios.Entities
{
    public class Talla
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public HashSet<PrendaTalla> PrendasTallas { get; set; }
    }
}
