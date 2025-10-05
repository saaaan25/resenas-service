namespace reseñas.Dtos.Resenas
{
    public class UpdateResenaRequestDto
    {
        public string Comentario { get; set; } = string.Empty;
        public decimal Calificacion { get; set; }
    }
}