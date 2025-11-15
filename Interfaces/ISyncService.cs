namespace reseñas.Interfaces
{
    public interface ISyncService
    {
        Task SyncProductos();
        Task SyncOrdenes();
        Task SyncOrdenItems();
    }
}