using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;// Para el control de "Logging"
using _04.Logging.Services;

namespace _04.Logging.Controllers
{
    public class DefaultController : Controller
    {
        // Variable para hacer la inyección de dependecias.
        private readonly IEmailProviderService _emailProviderService;

        // Interface por defecto para controlar los "Logging"
        private readonly ILogger _logger;        

        //  Crear un constructor y pasar una Interfaz como parámetro
        //  para realizar una "INYECCIÓN DE DEPENDENCIAS".

        //  NOTA: Esto se debe hacer en el constructor.
        //  Las dependencias son ejecutadas en el controlador, las dependencias
        //  van a cargar y van a leer la configuración, se va a inyectar y va a
        //  estar disponible para el proyecto.


        // Constructor
        public DefaultController(IEmailProviderService emailProviderService, ILogger<DefaultController> logger)
        {
            this._emailProviderService = emailProviderService;

            // Inyección de dependencias
            this._logger = logger;
        }
        public IActionResult Index()
        {
            // Enviar información al logging.
            // Nivel de log: Informativo.
            this._logger.LogInformation("Metodo: Index");

            //return View();
            return Ok(this._emailProviderService.Send());
        }
    }
}