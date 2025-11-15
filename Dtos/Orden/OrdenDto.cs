namespace reseñas.Dtos.Orden
{
    public class OrdenDto
    {
        public Guid Id { get; set; }
        public int UsuarioId { get; set; }
        public List<OrdenItemDto> Items { get; set; } = new();
    }
}