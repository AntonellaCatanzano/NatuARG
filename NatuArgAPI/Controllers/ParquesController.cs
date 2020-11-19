using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatuArgAPI.Data.Contracts;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetParqueAsync(int id)
        {
            var parque = await _parqueRepository.GetParqueAsync(id);

            if (parque == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ParqueDto>(parque));
        }
    }
}
