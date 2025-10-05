using Microsoft.AspNetCore.Mvc;
using reseñas.Data;
using reseñas.Dtos.Resenas;
using reseñas.Interfaces;
using reseñas.Mappers;

namespace reseñas.Controllers
{
    [Route("/api/resenas")]
    [ApiController]
    public class ResenaController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IResenaRepository _resenaRepository;
        public ResenaController(AppDBContext context, IResenaRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resenas = await _resenaRepository.GetAllAsync();

            var resenasResult = resenas.Select(p => p.ToResenaDto());

            return Ok(resenasResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var resena = await _resenaRepository.GetByIdAsync(id);

            if (resena == null)
            {
                return NotFound();
            }

            return Ok(resena.ToResenaDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateResenaRequestDto insertDto)
        {
            var resena = insertDto.ToResenaFromCreateDto();

            await _resenaRepository.CreateAsync(resena);

            return CreatedAtAction(nameof(GetById), new { id = resena.Id }, resena.ToResenaDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var resena = await _resenaRepository.DeleteAsync(id);

            if (resena == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateResenaRequestDto updateDto)
        {
            var resena = await _resenaRepository.UpdateAsync(id, updateDto);

            if (resena == null)
            {
                return NotFound();
            }

            return Ok(resena.ToResenaDto());
        }
    }
}