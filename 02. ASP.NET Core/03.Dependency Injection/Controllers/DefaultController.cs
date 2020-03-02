using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _03.Dependency_Injection.Services;
using Microsoft.AspNetCore.Mvc;

namespace _03.Dependency_Injection.Controllers
{
    // Controlador creado
    public class DefaultController : Controller
    {
        // Variable para hacer la inyección de dependecias.
        private readonly IEmailProviderService _emailProviderService;

        //  Crear un constructor y pasar una Interfaz como parámetro
        //  para realizar una "INYECCIÓN DE DEPENDENCIAS".
        
        //  NOTA: Esto se debe hacer en el constructor.
        //  Las dependencias son ejecutadas en el controlador, las dependencias
        //  van a cargar y van a leer la configuración, se va a inyectar y va a
        //  estar disponible para el proyecto.

        public DefaultController(IEmailProviderService emailProviderService)
        {
            this._emailProviderService = emailProviderService;
        }
        // Los métodos son las acciones que se van a compartir.
        public IActionResult Index()
        {
            //return View();

            // Retornar un status (Ok)
            //return Ok("03.Dependency Injection!");
            //return _emailProviderService.Send();
            return Ok(_emailProviderService.Send());
        }
    }
}