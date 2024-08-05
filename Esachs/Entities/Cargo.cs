namespace achsservicios.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public HashSet<Funcionario> Funcionarios { get; set; }
    }
}
