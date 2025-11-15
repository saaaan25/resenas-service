namespace reseñas.Dtos.Orden
{
    public class RemoteOrdenDto
    {
        public string _id { get; set; } = string.Empty;
        public int usuarioId { get; set; }
        public RemoteOrdenItemDto[] items { get; set; } = Array.Empty<RemoteOrdenItemDto>();
    }
}