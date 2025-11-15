using reseñas.Dtos.Orden;
using reseñas.Interfaces;
using reseñas.Models;

namespace reseñas.Services
{
    public class SyncService : ISyncService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly IProductoRepository _productoRepo;
        private readonly IOrdenRepository _ordenRepo;
        private readonly IOrdenItemRepository _ordenItemRepo;

        public SyncService(
            HttpClient client,
            IConfiguration config,
            IProductoRepository productoRepo,
            IOrdenRepository ordenRepo,
            IOrdenItemRepository ordenItemRepo)
        {
            _client = client;
            _config = config;
            _productoRepo = productoRepo;
            _ordenRepo = ordenRepo;
            _ordenItemRepo = ordenItemRepo;
        }

        public async Task SyncOrdenes()
        {
            var baseUrl = _config["ORDERS_QUERY_URL"];
            int page = 1;

            var all = new List<Orden>();

            while (true)
            {
                var list = await _client.GetFromJsonAsync<ResponseDto>(
                    $"{baseUrl}/api/orders?page={page}&limit=100");

                if (list == null || list.Data.Count == 0)
                    break;

                foreach (var o in list.Data)
                {
                    var detail = await _client.GetFromJsonAsync<RemoteOrdenDetailDto>(
                        $"{baseUrl}/api/orders/{o._id}"
                    );

                    if (detail == null)
                        continue;

                    all.Add(new Orden
                    {
                        Id = Guid.Parse(detail._id),
                        UsuarioId = detail.usuarioId
                    });
                }

                if (page >= list.LastPage)
                    break;

                page++;
            }

            await _ordenRepo.SyncOrdenesAsync(all);
        }

        public async Task SyncOrdenItems()
        {
            var baseUrl = _config["ORDERS_QUERY_URL"];
            int page = 1;

            var items = new List<OrdenItem>();

            while (true)
            {
                var response = await _client.GetFromJsonAsync<ResponseDto>(
                    $"{baseUrl}/api/orders?page={page}&limit=100"
                );

                if (response == null || response.Data.Count == 0)
                    break;

                foreach (var o in response.Data)
                {
                    var detail = await _client.GetFromJsonAsync<RemoteOrdenDetailDto>(
                        $"{baseUrl}/api/orders/{o._id}"
                    );

                    if (detail == null)
                        continue;

                    foreach (var it in detail.items)
                    {
                        items.Add(new OrdenItem
                        {
                            OrdenId = Guid.Parse(detail._id),
                            ProductoId = it.producto_id
                        });
                    }
                }

                if (page >= response.LastPage)
                    break;

                page++;
            }

            await _ordenItemRepo.SyncOrdenItemsAsync(items);
        }

        public async Task SyncProductos()
        {
            var url = $"{_config["PRODUCTS_QUERY_URL"]}/api/productos";

            var productosRemote =
                await _client.GetFromJsonAsync<List<Producto>>(url);

            if (productosRemote != null)
                await _productoRepo.SyncProductosAsync(productosRemote);
        }

    }

}