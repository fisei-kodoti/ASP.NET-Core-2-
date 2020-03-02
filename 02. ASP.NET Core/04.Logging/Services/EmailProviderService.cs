using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;//Agregado.

namespace _04.Logging.Services
{
    public class EmailProviderAService : IEmailProviderService
    {
        private readonly ILogger _logger;//Para inyección de dependencias.

        public EmailProviderAService(ILogger<EmailProviderAService> logger)
        {
            this._logger = logger;
        }
        public string Send()
        {
            // Enviar información al "Logging".
            this._logger.LogInformation($"Trabajando con la clase: {this.GetType().Name}");

            var success = false;

            if (success)
            {
                this._logger.LogWarning("No se pudo conectar al proveedor de correo");
            }
            else
            {
                this._logger.LogInformation("Se pudo conectar al servidor de correo");
            }


            var body = "Cuerpo del mensaje";
            var subject = "Asunto del mensaje";

            this._logger.LogInformation("Se preparo el cuerpo");

            try
            {
                throw new Exception("Se perdio la conexion con el proveedor");
            }
            catch(Exception e)
            {
                this._logger.LogError("Error: " + e.Message);
            }
       

            //throw new NotImplementedException();
            return this.GetType().Name;// Retorna el nombre de la clase
        }
    }


    public class EmailProviderBService : IEmailProviderService
    {
        public string Send()
        {
            //throw new NotImplementedException();
            return this.GetType().Name;// Retorna el nombre de la clase
        }
    }
}
