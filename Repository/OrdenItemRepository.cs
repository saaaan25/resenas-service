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
            _context.ChangeTracker.Clear();

            var duplicados = items
                .GroupBy(x => x.Id)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            items = items
                .GroupBy(x => x.Id)
                .Select(g => g.First())
                .ToList();

            foreach (var item in items)
            {
                var existing = await _context.OrdenItems
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Id == item.Id);

                if (existing == null)
                {
                    _context.OrdenItems.Add(item);
                }
                else
                {
                    _context.OrdenItems.Update(item);
                }
            }

            await _context.SaveChangesAsync();
        }

    }
}