using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;// agregado.
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kodoti_00
{
    // 3) esta clase es el corazon del proyecto, porque aqui se especifica
    //    muchas de las caracteristicas que se va a usar.
    //    Esta clase permite personalizar el proyecto.
    public class Startup
    {
        // Agregado: (1)
        // esta interface establece los métodos para la lectura.
        private readonly IConfiguration Configuration;

        //  Agregado: (2)
        //  hay que agregar el constructor para la
        //           inyección de dependencias.
        public Startup(IConfiguration configuration)
        {
            //  Se pasa por inyección de dependencias al constructor
            //  el objeto (configuration) ya instanciado, y se guarda 
            //  en la variable (Configuration) para poder acceder a sus
            //  valores desde cualquier parte de la clase.

            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // en este método se puede agregar nuestros propios servicios
            // y dependencias.

            // Agregado: (3)
            // Obtener el valor de la propiedad "WebUrl" creada en el 
            //  archivo: <appsettings.json> y guardamos en la variable.
            //var webUrl = Configuration.GetValue<string>("WebUrl");
            string webUrl = Configuration.GetValue<string>("WebUrl");

            // Mostrar en la consola.
            Console.WriteLine("Valor: " + webUrl);
            // Pausa.
            //Console.Read();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // este metodo permite configurar las peticiones HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // esto habilita la página de error en producción.
                app.UseDeveloperExceptionPage();
            }

            // habilita el routing
            app.UseRouting();

            // al ejecutar se llama este metodo.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
