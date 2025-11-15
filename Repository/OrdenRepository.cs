using Microsoft.EntityFrameworkCore;
using reseñas.Data;
using reseñas.Interfaces;
using reseñas.Models;

namespace reseñas.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly AppDBContext _context;
        public OrdenRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Orden>> GetAllAsync() 
            => await _context.Ordenes.Include(o => o.Items).ToListAsync();


        public async Task<List<Orden>> GetByUsuarioAsync(int usuarioId)
            => await _context.Ordenes.Where(o => o.UsuarioId == usuarioId)
            .Include(o => o.Items).ToListAsync();

        public async Task SyncOrdenesAsync(List<Orden> ordenes)
        {
            _context.OrdenItems.RemoveRange(_context.OrdenItems);
            _context.Ordenes.RemoveRange(_context.Ordenes);
            
            await _context.Ordenes.AddRangeAsync(ordenes);
            await _context.SaveChangesAsync();

            var allItems = ordenes.SelectMany(o => o.Items).ToList();
            if (allItems.Any())
            {
                await _context.OrdenItems.AddRangeAsync(allItems);
                await _context.SaveChangesAsync();
            }
        }

    }
}