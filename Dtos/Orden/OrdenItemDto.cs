namespace reseñas.Dtos.Orden
{
    public class OrdenItemDto
    {
        public int Id { get; set; }
        public Guid OrdenId { get; set; }
        public int ProductoId { get; set; }
    }
}