using reseñas.Dtos.Resenas;
using reseñas.Models;

namespace reseñas.Interfaces
{
    public interface IResenaRepository
    {
        Task<List<Resena>> GetAllAsync();
        Task<Resena?> GetByIdAsync(int id);
        Task<Resena> CreateAsync(Resena resena);
        Task<Resena?> UpdateAsync(int id, UpdateResenaRequestDto resena);
        Task<Resena?> DeleteAsync(int id);
    }
}