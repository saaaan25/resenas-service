using Microsoft.AspNetCore.Mvc;
using reseñas.Dtos.Orden;
using reseñas.Interfaces;

namespace reseñas.Controllers
{
    [ApiController]
    [Route("api/ordenes")]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenRepository _ordenRepository;

        public OrdenController(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordenes = await _ordenRepository.GetAllAsync();

            var dtos = ordenes.Select(o => new OrdenDto
            {
                Id = o.Id,
                UsuarioId = o.UsuarioId,
                Items = o.Items.Select(i => new OrdenItemDto
                {
                    Id = i.Id,
                    OrdenId = i.OrdenId,
                    ProductoId = i.ProductoId
                }).ToList()
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var ordenes = await _ordenRepository.GetByUsuarioAsync(usuarioId);

            var dtos = ordenes.Select(o => new OrdenDto
            {
                Id = o.Id,
                UsuarioId = o.UsuarioId,
                Items = o.Items.Select(i => new OrdenItemDto
                {
                    Id = i.Id,
                    OrdenId = i.OrdenId,
                    ProductoId = i.ProductoId
                }).ToList()
            }).ToList();

            return Ok(dtos);
        }
    }
}