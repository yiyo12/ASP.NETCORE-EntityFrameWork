using Ejemplo1.Models;
using Ejemplo1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Authorization;

namespace Ejemplo1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private InterfazAmigo interfaceAMIGO;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;

        public HomeController(InterfazAmigo AmigoAlmacen, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            interfaceAMIGO = AmigoAlmacen;
            _hosting = hostingEnvironment;



        }


        //Sobrecarga de rutas
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        //Con esto podemos decir que aunque tengamos el authorize a nivel de clase, podemos ver este index
        //[AllowAnonymous]
        public ViewResult Index()
        {

            var modelo = interfaceAMIGO.getAllAmigos();
            return View(modelo);


        }


        //Sobre carga de rutas
        //[Route("Home/Details/{id?}")]
        //Asi s epasan datos de un modelo a una vista
        public ViewResult Details(int? id)
        {
        
            DetallesView detalles = new DetallesView();
            detalles.amigo = interfaceAMIGO.dameDatosAmigo(id ?? 1);
            detalles.titulo = "Lista amigos View models";
            detalles.subTitulo = "sub titulo view models";

            if (detalles.amigo == null)
            {
                Response.StatusCode = 404;
                return View("AmigoNoEncontrado",id);
            }

            return View(detalles);

        }


        //[Route("Home/Index")]
        [HttpGet]
        // [Authorize] otra manera es declararlo a nivel de clase en este caso no dejara hacer 
        //Nada de los metodos de home controller hasta que nos loggemos
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
       // [Authorize] otra manera es declararlo a nivel de clase en este caso no dejara hacer 
       //Nada de los metodos de home controller hasta que nos loggemos
        public IActionResult Create(CrearAmigoModelo a)
        {
            if (ModelState.IsValid)
            {
                //guardar el string de la imagen
                string pathImagen = null;
                if (a.Foto != null)
                {
                    string ficheroImagen = Path.Combine(_hosting.WebRootPath, "images");
                    pathImagen = Guid.NewGuid().ToString() + a.Foto.FileName;
                    string rutaDefinitiva = Path.Combine(ficheroImagen, pathImagen);
                    Console.WriteLine("rutaDefinitiva" + rutaDefinitiva);
                    a.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));

                }
                //despues de hacer las validaciones en la calse amigo vemos si se cumplen todas
                Amigo amigoNEW = new Amigo();
                amigoNEW.Nombre = a.Nombre;
                amigoNEW.Email = a.Email;
                amigoNEW.Ciudad = a.Ciudad;
                amigoNEW.rutaFoto = pathImagen;
                interfaceAMIGO.nuevoAmigo(amigoNEW);
                //redirijimos ala vista detalles y que acepte el id como paramegtro del nuevo amigo
                return RedirectToAction("details", new { id = amigoNEW.Id });


            }
            return View();

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Amigo amigo = interfaceAMIGO.dameDatosAmigo(id);
            EditAmigosModel amigoEditar = new EditAmigosModel
            {
                Id = amigo.Id,
                Nombre = amigo.Nombre,
                Email = amigo.Email,
                Ciudad = amigo.Ciudad,
                rutaFotoExistente = amigo.rutaFoto
            };
            return View(amigoEditar);
        }

        [HttpPost]
        public IActionResult Edit(EditAmigosModel model)
        {

            //comprobacion de datos
            if (ModelState.IsValid)
            {
                Amigo amigo = interfaceAMIGO.dameDatosAmigo(model.Id);
                //Actualizamos los datos de nuestro objeto del modelo 
                amigo.Nombre = model.Nombre;
                amigo.Email = model.Email;
                amigo.Ciudad = model.Ciudad;
                if (model.Foto != null)
                {
                    //Por si el usuario sube una foto borramos la anterior
                    if (model.rutaFotoExistente != null)
                    {
                        string ruta = Path.Combine(_hosting.WebRootPath, "images", model.rutaFotoExistente);
                        System.IO.File.Delete(ruta);
                    }

                    //Se guarda la foto 
                    amigo.rutaFoto = SubirImagen(model);
                }

                Amigo amigoModificado = interfaceAMIGO.modificar(amigo);
                return RedirectToAction("index");

            }
            return View(model);
        }

        private string SubirImagen(EditAmigosModel model)
        {
            string nombreFichero = null;
            if (model.Foto != null)
            {
                string carpeta = Path.Combine(_hosting.WebRootPath, "images");
                nombreFichero = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string rutaFinal = Path.Combine(carpeta, nombreFichero);
                using (var fileStream = new FileStream(rutaFinal, FileMode.Create))
                {
                    model.Foto.CopyTo(fileStream);
                }
            }


            return nombreFichero;
        }


    }
}
