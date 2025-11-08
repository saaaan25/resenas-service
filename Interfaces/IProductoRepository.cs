using reseñas.Models;

namespace reseñas.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<List<Resena>> GetResenasByProductoAsync(int productoId);
    }
}