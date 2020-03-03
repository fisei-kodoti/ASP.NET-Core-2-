using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _02.Controles_y_Routes.Models;

namespace _02.Controles_y_Routes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ruta: home/index
        // NOTA: Pero como es el contralador por defecto no hace falta
        //       indicar la ruta, para el resto acciones o metodo si se
        //       debe indicar la ruta para el ruteo.
        public IActionResult Index()
        {
            // Retorna una vista segun el codigo.
            // Puede retornar una vista o un texto plano (json) serializado.
            // NOTA: Una accion es un metodo.
            return View();
        }

        // ruta: home/privacy
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
