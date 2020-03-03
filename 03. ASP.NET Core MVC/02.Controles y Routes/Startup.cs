using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _02.Controles_y_Routes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Modo de desarrollo
            if (env.IsDevelopment())
            {
                // Mostrar una página de error
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Sino estamos en el modo desarrollo, entonces mostrar
                // una página de error personalizada
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Uso de midlewares: es un intermediario que cambia el comportamiento

            // Fuerza a usar https redireccion, 
            //hace que siemmre se use https, se puede crear MidleWare
            app.UseHttpsRedirection();
            // Habilita para que el servidor pueda hacer "Request" a los archivos
            // a la carpeta: wwwroot
            app.UseStaticFiles();

            // Esto ya no esta habilitado en la nueva version
            // Habilita las politicas de cookies.
            //app.UseCookiePolicy();

            // Activa el routing de los controladores
            app.UseRouting();

            // Activa las capacidades de autorizacion
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
