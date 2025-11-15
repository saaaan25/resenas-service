namespace reseñas.Dtos.Orden
{
    public class ResponseDto
    {
        public List<RemoteOrdenDto> Data { get; set; } = new();
        public int Total { get; set; }
        public int Page { get; set; }
        public int LastPage { get; set; }
    }
}