namespace reseñas.Dtos.Resenas
{
    public class CreateResenaRequestDto
    {
        public int Id_detalle_orden { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public decimal Calificacion { get; set; }
        public DateTimeOffset Fecha_resena { get; set; }
    }
}