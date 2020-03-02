using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc;//agregado

using _04.Logging.Services;

namespace _04.Logging
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //  Agregado
            //  Indica con que servicios queremos trabajar con el servicio Mvc,
            //  esto va en el método: ConfigureServices
            services.AddMvc(option => option.EnableEndpointRouting = false);

            // Agregar el servicio de "Logging".
            services.AddLogging();

            // Transient.
            // Inyección de dependencias.
            // Agregar un servicio

            //  Hay 3:
            //  1) transient (Se crea automaticamente)
            //  2) scoped (Para el request actual)
            //  3) singleton (Esta siempre presente hasta que se reinicie el servidor)

            //  Esto quiere decir que la interfaz "IEmailProviderService" va a trabajar
            //  con todos los métodos implementados en la clase "EmailProviderAService".
        
            services.AddTransient<IEmailProviderService, EmailProviderAService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("04.Logging!");
            //    });
            //});

            // Agregado
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");

            });
        }
    }
}
