namespace reseñas.Models
{
    public class Orden
    {
        public Guid Id { get; set; }
        public int UsuarioId { get; set; }
        public List<OrdenItem> Items { get; set; } = new();
    }
}