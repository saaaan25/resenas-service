using reseñas.Models;

namespace reseñas.Interfaces
{
    public interface IOrdenRepository
    {
        Task<List<Orden>> GetAllAsync();
        Task<List<Orden>> GetByUsuarioAsync(int usuarioId);
        Task SyncOrdenesAsync(List<Orden> ordenes);
    }
}