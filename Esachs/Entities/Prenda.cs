using System.ComponentModel.DataAnnotations;

namespace achsservicios.Entities
{
    public class Prenda
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string DisplayName { get; set; }
        public string Proveedor { get; set; }
        public char Sexo { get; set; }
        public ICollection<PrendaTalla> PrendasTallas { get; set; }
        public ICollection<Uniforme> Uniforme { get; set; }
    }
}
