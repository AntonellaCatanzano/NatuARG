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

        [HttpGet]
        public async Task<ActionResult> GetAtraccionAsync()
        {
            var atracciones = await _atraccionRepository.GetAtraccionAsync();

            if (atracciones is null)
            {
                ModelState.AddModelError("", "Error al recuperar las atracciones.");
                return NotFound();
            }

            return Ok(atracciones);
        }

        [HttpGet("{id:int}", Name = "GetAtraccionAsync")]
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

        [HttpPost]
        public async Task<ActionResult> PostAtraccionAsync([FromBody] AtraccionDto atraccionDto)
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

            atraccionDto = _mapper.Map<AtraccionDto>(atraccion);

            return CreatedAtRoute("GetAtraccionAsync", new { id = atraccionDto.Id }, atraccionDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAtraccionAsync(int id, [FromBody] AtraccionDto atraccionDto)
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

            return CreatedAtRoute("GetAtraccionAsync", new { id = atraccionDto.Id }, atraccionDto);
        }

        [HttpDelete("{id:int}")]
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
