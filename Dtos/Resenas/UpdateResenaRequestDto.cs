namespace reseñas.Dtos.Resenas
{
    public class UpdateResenaRequestDto
    {
        public string? Descripcion { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Porcentaje { get; set; }
        public DateTimeOffset? Fecha_inicio { get; set; } 
        public DateTimeOffset? Fecha_limite { get; set; } 
    }
}