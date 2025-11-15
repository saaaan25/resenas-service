using Microsoft.AspNetCore.Mvc;
using resenas.Dtos.Producto;
using reseñas.Interfaces;

namespace reseñas.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoRepository.GetAllAsync();

            var dtos = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _productoRepository.GetByIdAsync(id);
            if (p == null) return NotFound();

            var dto = new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion
            };

            return Ok(dto);
        }

        [HttpGet("orden-item/{ordenItemId}")]
        public async Task<IActionResult> GetProductoByOrdenItemId(int ordenItemId)
        {
            var producto = await _productoRepository.GetProductoByOrdenItemIdAsync(ordenItemId);

            if (producto == null)
                return NotFound(new { message = $"No existe un producto asociado al ordenItemId {ordenItemId}" });

            var dto = new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion
            };

            return Ok(dto);
        }

        [HttpGet("{id}/reseñas")]
        public async Task<IActionResult> GetResenas(int id)
        {
            var resenas = await _productoRepository.GetResenasByProductoAsync(id);
            return Ok(resenas); // Aquí tus reseñas ya son DTO-like o modelo, tú decides
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetProductosComprados(int usuarioId)
        {
            var productos = await _productoRepository.GetProductosByUsuarioAsync(usuarioId);

            var dtos = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion
            }).ToList();

            return Ok(dtos);
        }
    }
}