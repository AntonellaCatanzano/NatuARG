using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatuArgAPI.Data.Contracts;
using NatuArgAPI.Models;
using NatuArgAPI.Models.Dtos;

namespace NatuArgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "NatuArgOpenApiParques")]
    [ApiController]
    public class ParquesController : Controller
    {
        private readonly IParqueRepository _parqueRepository;
        private readonly IMapper _mapper;

        public ParquesController(IParqueRepository parqueRepository, IMapper mapper)
        {
            _parqueRepository = parqueRepository;
            _mapper = mapper;
        }

        // GET: api/parques
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetParquesAsync()
        {
            var parques = await _parqueRepository.GetParquesAsync();

            return Ok(_mapper.Map<List<ParqueDto>>(parques));
        }

        // GET: api/parques/1
        [HttpGet("{id:int}", Name = "GetParqueAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetParqueAsync(int id)
        {
            var parque = await _parqueRepository.GetParqueAsync(id);

            if (parque == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ParqueDto>(parque));
        }

        // POST: api/parques
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostParqueAsync([FromBody] ParqueDto parqueDto)
        {
            if (parqueDto is null)
            {
                return BadRequest();
            }

            if (await _parqueRepository.ParqueExistAsync(parqueDto.Nombre))
            {
                ModelState.AddModelError("","Ya existe un parque nacional con ese nombre.");
                return StatusCode(404, ModelState);
            }

            var parque = _mapper.Map<Parque>(parqueDto);

            if (!await _parqueRepository.CreateParqueAsync(parque))
            {
                ModelState.AddModelError("", "Ha ocurrido un error al insertar el parque nacional.");
                return StatusCode(500, ModelState);
            }

            var newParqueDto = _mapper.Map<ParqueDto>(parque);

            return CreatedAtRoute("GetParqueAsync", new { id = newParqueDto.Id }, newParqueDto);
        }

        // PUT: api/parques/1
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutParqueAsync(int id, [FromBody] ParqueDto parqueDto)
        {
            if (parqueDto is null || id != parqueDto.Id)
            {
                return BadRequest();
            }

            if (!await _parqueRepository.ParqueExistAsync(parqueDto.Nombre))
            {
                ModelState.AddModelError("", "El parque nacional no existe.");
                return StatusCode(404, ModelState);
            }

            var parque = _mapper.Map<Parque>(parqueDto);

            if (!await _parqueRepository.UpdateParqueAsync(parque))
            {
                ModelState.AddModelError("", "Ha ocurrido un error al actualizar el parque nacional.");
                return StatusCode(500, ModelState);
            }

            var newParqueDto = _mapper.Map<ParqueDto>(parque);
            
            return NoContent();
        }

        // DELETE: api/parques/1
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteParqueAsync(int id)
        {
            if (!await _parqueRepository.ParqueExistAsync(id))
            {
                ModelState.AddModelError("", "El parque nacional no existe.");
                return StatusCode(404, ModelState);
            }

            var parque = await _parqueRepository.GetParqueAsync(id);

            if (!await _parqueRepository.DeleteParqueAsync(parque))
            {
                ModelState.AddModelError("", "Ha ocurrido un error al eliminar el parque nacional.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
