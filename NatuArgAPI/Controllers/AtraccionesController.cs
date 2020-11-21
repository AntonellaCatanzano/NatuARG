using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatuArgAPI.Data.Contracts;
using NatuArgAPI.Models;
using NatuArgAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatuArgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "NatuArgOpenApiAtracciones")]
    [ApiController]
    public class AtraccionesController : Controller
    {
        private readonly IAtraccionRepository _atraccionRepository;
        private readonly IMapper _mapper;

        public AtraccionesController(IAtraccionRepository atraccionRepository, IMapper mapper)
        {
            _atraccionRepository = atraccionRepository;
            _mapper = mapper;
        }

        // GET: api/atracciones
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAtraccionAsync()
        {
            var atracciones = await _atraccionRepository.GetAtraccionAsync();

            if (atracciones is null)
            {
                ModelState.AddModelError("", "Error al recuperar las atracciones.");
                return NotFound();
            }

            return Ok(_mapper.Map<List<AtraccionDto>>(atracciones));
        }

        // GET: api/atracciones/1
        [HttpGet("{id:int}", Name = "GetAtraccionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAtraccionAsync(int id)
        {
            var atraccion = await _atraccionRepository.GetAtraccionAsync(id);

            if (atraccion is null)
            {
                ModelState.AddModelError("", "Error al recuperar la atraccion.");
                return NotFound();
            }

            return Ok(atraccion);
        }

        // POST: api/atracciones
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostAtraccionAsync([FromBody] AtraccionInsertDto atraccionDto)
        {
            if (await _atraccionRepository.AtraccionExistAsync(atraccionDto.Id))
            {
                ModelState.AddModelError("", "La atraccion ya existe.");
                return BadRequest(ModelState);
            }

            if (atraccionDto is null)
            {
                return BadRequest();
            }

            var atraccion = _mapper.Map<Atraccion>(atraccionDto);

            if (!await _atraccionRepository.CreateAtraccionAsync(atraccion))
            {
                ModelState.AddModelError("", "Error al insertar la atraccion.");
                return StatusCode(500, ModelState);
            }

            atraccionDto = _mapper.Map<AtraccionInsertDto>(atraccion);

            return CreatedAtRoute("GetAtraccionAsync", new { id = atraccionDto.Id }, atraccionDto);
        }

        // PUT: api/atracciones/1
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutAtraccionAsync(int id, [FromBody] AtraccionInsertDto atraccionDto)
        {
            if (atraccionDto is null || id != atraccionDto.Id)
            {
                return BadRequest();
            }

            if (!await _atraccionRepository.AtraccionExistAsync(atraccionDto.Id))
            {
                ModelState.AddModelError("", "La atraccion no existe.");
                return BadRequest(ModelState);
            }

            var atraccion = _mapper.Map<Atraccion>(atraccionDto);

            if (!await _atraccionRepository.UpdateAtraccionAsync(atraccion))
            {
                ModelState.AddModelError("", "Error al actualizar la atraccion.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // DELETE: api/atracciones/1
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAtraccionAsync(int id)
        {
            if (!await _atraccionRepository.AtraccionExistAsync(id))
            {
                ModelState.AddModelError("", "La atraccion no existe.");
                return BadRequest(ModelState);
            }

            var atraccion = await _atraccionRepository.GetAtraccionAsync(id);

            if (!await _atraccionRepository.DeleteAtraccionAsync(atraccion))
            {
                ModelState.AddModelError("", "Error al eliminar la atraccion.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
