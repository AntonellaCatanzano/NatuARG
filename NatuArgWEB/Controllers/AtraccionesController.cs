using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NatuArgWEB.Data.Contracts;

namespace NatuArgWEB.Controllers
{
    public class AtraccionesController : Controller
    {
        private readonly IAtraccionesRepository _atraccionesRepo;

        public AtraccionesController(IAtraccionesRepository atraccionesRepository)
        {
            _atraccionesRepo = atraccionesRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.ParqueId = id;
            var atracciones = await _atraccionesRepo.GetAllAsync(StaticDetails.AtraccionesApiPath);
            return View(atracciones);
        }
    }
}
