namespace reseñas.Models
{
    public class OrdenItem
    {
        public int Id { get; set; }
        public Guid OrdenId { get; set; }
        public int ProductoId { get; set; }
    }
}