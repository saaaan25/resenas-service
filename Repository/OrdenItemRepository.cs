using Microsoft.EntityFrameworkCore;
using reseñas.Data;
using reseñas.Interfaces;
using reseñas.Models;

namespace reseñas.Repository
{
    public class OrdenItemRepository : IOrdenItemRepository
    {
        private readonly AppDBContext _context;
        public OrdenItemRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<OrdenItem>> GetAllAsync() => await _context.OrdenItems.ToListAsync();

        public async Task SyncOrdenItemsAsync(List<OrdenItem> items)
        {
            _context.OrdenItems.RemoveRange(_context.OrdenItems);
            await _context.OrdenItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

    }
}