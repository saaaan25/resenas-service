using Microsoft.EntityFrameworkCore;
using reseñas.Data;
using reseñas.Dtos.Resenas;
using reseñas.Interfaces;
using reseñas.Models;

namespace reseñas.Repository
{
    public class ResenaRepository : IResenaRepository
    {
        private readonly AppDBContext _context;
        public ResenaRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Resena> CreateAsync(Resena resena)
        {
            await _context.Resenas.AddAsync(resena);
            await _context.SaveChangesAsync();
            return resena;
        }

        public async Task<Resena?> DeleteAsync(int id)
        {
            var resena = await _context.Resenas.FirstOrDefaultAsync(p => p.Id == id);

            if (resena == null)
            {
                return null;
            }

            _context.Resenas.Remove(resena);
            await _context.SaveChangesAsync();
            return resena;
        }

        public async Task<List<Resena>> GetAllAsync()
        {
            return await _context.Resenas.ToListAsync();
        }

        public async Task<Resena?> GetByIdAsync(int id)
        {
            return await _context.Resenas.FindAsync(id);
        }

        public async Task<Resena?> UpdateAsync(int id, UpdateResenaRequestDto resena)
        {
            var existingResena = await _context.Resenas.FirstOrDefaultAsync(p => p.Id == id);

            if (existingResena == null)
            {
                return null;
            }

            if (resena.Id_detalle_orden.HasValue)
            {
                existingResena.Id_detalle_orden = resena.Id_detalle_orden.Value;
            }
            
            if (resena.Comentario != null)
            {
                existingResena.Comentario = resena.Comentario;
            }

            if (resena.Calificacion.HasValue)
            {
                existingResena.Calificacion = resena.Calificacion.Value;
            }

            if (resena.Fecha_resena.HasValue)
            {
                existingResena.Fecha_resena = resena.Fecha_resena.Value.ToUniversalTime();
            }

            await _context.SaveChangesAsync();
            return existingResena;
        }

    }
}