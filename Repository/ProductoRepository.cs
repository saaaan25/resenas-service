using Microsoft.EntityFrameworkCore;
using reseñas.Data;
using reseñas.Interfaces;
using reseñas.Models;

namespace reseñas.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDBContext _context;
        public ProductoRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync() => await _context.Productos.ToListAsync();

        public async Task<Producto?> GetByIdAsync(int id) => await _context.Productos.FindAsync(id);

        public async Task<Producto?> GetProductoByOrdenItemIdAsync(int ordenItemId)
        {
            var ordenItem = await _context.OrdenItems
                .FirstOrDefaultAsync(o => o.Id == ordenItemId);

            if (ordenItem == null)
                return null;

            return await _context.Productos
                .FirstOrDefaultAsync(p => p.Id == ordenItem.ProductoId);
        }

        public async Task<List<Producto>> GetProductosByUsuarioAsync(int usuarioId)
        {
            var productosIds = await _context.Ordenes
            .Where(o => o.UsuarioId == usuarioId)
            .SelectMany(o => o.Items)
            .Select(i => i.ProductoId)
            .Distinct()
            .ToListAsync();

            return await _context.Productos
            .Where(p => productosIds.Contains(p.Id))
            .ToListAsync();
        }

        public async Task<List<Resena>> GetResenasByProductoAsync(int productoId)
        {
            return await _context.Resenas
            .Where(r => r.Id_detalle_orden != 0)
            .Where(r => _context.OrdenItems.Any(oi =>
                oi.Id == r.Id_detalle_orden &&
                oi.ProductoId == productoId))
            .ToListAsync();
        }

        public async Task SyncProductosAsync(List<Producto> productos)
        {
            _context.Productos.RemoveRange(_context.Productos);
            await _context.Productos.AddRangeAsync(productos);
            await _context.SaveChangesAsync();
        }
    }
}