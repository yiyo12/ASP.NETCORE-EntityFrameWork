using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo1.Models;
using EjemploNetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ejemplo1
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //No agrega todas las funcionalidades que trae addMvc 
            //services.AddMvcCore();

            //iniciar la instacia de las base de datos
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ConexionSQL")));

            //Crea un servicio  singleton y esta misma instancia es usada para las demas
            //Este mock es usado como si fuera nuestra base de datos ya que usamos hardcodeado los datos de los amigos sin una base de datos
            //services.AddSingleton<InterfazAmigo, mockAmigoRepositorio>();

            //Usando un servicio de sql como entrada de datos
            services.AddScoped<InterfazAmigo, SQLAmigoRepositorio>();


            //Agregar identity para agrear la configuracion predetermina para la gestion de identidades
            services.AddIdentity<ViewModels.UsuarioAplicacacion, IdentityRole>().
                AddErrorDescriber<ErroresCastellano>().
                AddEntityFrameworkStores<AppDbContext>();

            //Agregamos una ruta por defecto par aque el usuario se tenga que logear antes de poder hacer algo o ver algo
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Cuentas/Login";
                options.AccessDeniedPath = "/Cuentas/AccesoDenegado";
             });
               //Agregar nuestra configuracion a la validacion del formulario de los usuarios
            services.Configure<IdentityOptions>(opciones =>
            {
                opciones.Password.RequiredLength = 8;
                opciones.Password.RequiredUniqueChars = 3;
                opciones.Password.RequireNonAlphanumeric = false;

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                //Sirve para mostar menos lineas de informacion cuando se crea una exepcion
                DeveloperExceptionPageOptions de = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 2
                };
                app.UseDeveloperExceptionPage(de);
            } 

            else if ( env.IsProduction() || env.IsStaging())
            {
                 app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            
            //Para iniciar con el html por defecto siempre y cuando se llame index.cshtml o default.html
           /// app.UseDefaultFiles();
            app.UseStaticFiles();

    
            //Para que use autentificacion -- Es imporante que use authentication este antes de el ruteo
            app.UseAuthentication();
            //Toma la ruta por defecto en este caso homeControllerES LA MAS COMODA
            app.UseMvcWithDefaultRoute();
        
           

            //Para iniciar con archivos que no sean el defualt
            //DefaultFilesOptions def = new DefaultFilesOptions();
            //def.DefaultFileNames.Clear();
            //def.DefaultFileNames.Add("noDefault.html");
            //app.UseDefaultFiles(def);
            //app.UseStaticFiles();

            //Para definir nuestras rutas
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id}");

            //});

            //Especificar turas por atributo, en home controller 
            // app.UseMvc();


        }
    }
}
