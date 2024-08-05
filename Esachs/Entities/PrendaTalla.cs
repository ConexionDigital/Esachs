namespace achsservicios.Entities
{
    public class PrendaTalla
    {
        public int PrendaId { get; set; }
        public int TallaId { get; set; }
        public int Precio { get; set; }
        public string CodProducto { get; set; }
        public char Sexo { get; set; }
        public int CodSAP { get; set; }
        public Prenda Prenda { get; set; }
        public Talla Talla { get; set; }
    }
}
