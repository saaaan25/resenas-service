using Microsoft.AspNetCore.Mvc;
using reseñas.Interfaces;

namespace reseñas.Controllers
{
    [ApiController]
    [Route("api/sync")]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;

        public SyncController(ISyncService syncService)
        {
            _syncService = syncService;
        }

        [HttpPost("productos")]
        public async Task<IActionResult> SyncProductos()
        {
            await _syncService.SyncProductos();
            return Ok(new { message = "Productos sincronizados" });
        }

        [HttpPost("ordenes")]
        public async Task<IActionResult> SyncOrdenes()
        {
            await _syncService.SyncOrdenes();
            return Ok(new { message = "Órdenes sincronizadas" });
        }

        [HttpPost("orden-items")]
        public async Task<IActionResult> SyncOrdenItems()
        {
            await _syncService.SyncOrdenItems();
            return Ok(new { message = "OrdenItems sincronizados" });
        }
    }
}