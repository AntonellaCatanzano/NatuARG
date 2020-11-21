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
    [ApiController]
    public class ParquesController : ControllerBase
    {
        private readonly IParqueRepository _parqueRepository;
        private readonly IMapper _mapper;

        public ParquesController(IParqueRepository parqueRepository, IMapper mapper)
        {
            _parqueRepository = parqueRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetParquesAsync()
        {
            var parques = await _parqueRepository.GetParquesAsync();

            return Ok(_mapper.Map<List<ParqueDto>>(parques));
        }

        [HttpGet("{id:int}", Name = "GetParqueAsync")]
        public async Task<ActionResult> GetParqueAsync(int id)
        {
            var parque = await _parqueRepository.GetParqueAsync(id);

            if (parque == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ParqueDto>(parque));
        }

        [HttpPost]
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

        [HttpPut("{id:int}")]
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

            return CreatedAtRoute("GetParqueAsync", new { id = newParqueDto.Id }, newParqueDto);
        }

        [HttpDelete("{id:int}")]
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
