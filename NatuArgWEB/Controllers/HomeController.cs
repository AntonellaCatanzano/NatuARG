using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NatuArgWEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NatuArgWEB.Data.Contracts;

namespace NatuArgWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParquesRepository _parqueRepo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IParquesRepository parquesRepository, ILogger<HomeController> logger)
        {
            _parqueRepo = parquesRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var parques = await _parqueRepo.GetAllAsync(StaticDetails.ParquesApiPath);
            return View(parques);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
