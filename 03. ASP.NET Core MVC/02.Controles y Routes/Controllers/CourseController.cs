using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02.Controles_y_Routes.Controllers
{
    // Sobreescribir las rutas (URL)
    // NOTA:En lugar de usar las rutas por defecto: course/action
    //      establecer rutas personalizas y en español: cursos/descuentos
    [Route("Cursos")]
    public class CourseController: Controller
    {
        public IActionResult Index()
        {
            // Retornar un estatus "Ok" 200.
            return Ok("Acción: Index");
        }

        // Indicar la ruta como se va a acceder a la acción.
        // Establecer una ruta personalizada, y el verbo http al cual
        // va a responder la accion. Para nevegar por las URL normalmente
        // se usa el verbo "Get". Se pone el verbo http y el nombre
        [HttpGet("descuentos")]
        public IActionResult LastCoursesOffers()
        {
            return Ok("Página de descuentos");
        }
    }
}
