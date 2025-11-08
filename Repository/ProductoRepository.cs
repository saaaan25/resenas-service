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
        
        public Task<List<Resena>> GetResenasByProductoAsync(int productoId)
        {
            throw new NotImplementedException();
        }

    }
}