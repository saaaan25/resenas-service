using reseñas.Dtos.Resenas;
using reseñas.Models;

namespace reseñas.Mappers
{
    public static class ResenaMappers
    {
        public static ResenaDto ToResenaDto(this Resena resenaModel)
        {
            return new ResenaDto
            {
                Id = resenaModel.Id,
                Id_detalle_orden = resenaModel.Id_detalle_orden,
                Comentario = resenaModel.Comentario,
                Calificacion = resenaModel.Calificacion,
                Fecha_resena = resenaModel.Fecha_resena.ToUniversalTime()
            };
        }

        public static Resena ToResenaFromCreateDto(this CreateResenaRequestDto resenaDto)
        {
            return new Resena
            {
                Id_detalle_orden = resenaDto.Id_detalle_orden,
                Comentario = resenaDto.Comentario,
                Calificacion = resenaDto.Calificacion,
                Fecha_resena = resenaDto.Fecha_resena.ToUniversalTime()
            };
        }
    }
}