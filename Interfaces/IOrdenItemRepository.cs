using reseñas.Models;

namespace reseñas.Interfaces
{
    public interface IOrdenItemRepository
    {
        Task<List<OrdenItem>> GetAllAsync();
        Task SyncOrdenItemsAsync(List<OrdenItem> items);
    }
}