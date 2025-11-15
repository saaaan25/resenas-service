using Microsoft.AspNetCore.Mvc;
using reseñas.Dtos.Orden;
using reseñas.Interfaces;

namespace reseñas.Controllers
{
    [ApiController]
    [Route("api/orden-items")]
    public class OrdenItemController : ControllerBase
    {
        private readonly IOrdenItemRepository _ordenItemRepository;

        public OrdenItemController(IOrdenItemRepository ordenItemRepository)
        {
            _ordenItemRepository = ordenItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _ordenItemRepository.GetAllAsync();

            var dtos = items.Select(i => new OrdenItemDto
            {
                Id = i.Id,
                OrdenId = i.OrdenId,
                ProductoId = i.ProductoId
            }).ToList();

            return Ok(dtos);
        }
    }
}