namespace achsservicios.Entities
{
    public class CabPedidos
    {
        public int Id { get; set; }
        public string IdSolicitante { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int Estado { get; set; }
        public HashSet<DetPedidos> DetPedidos { get; set; }
    }
}
