using Ejemplo1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Controllers
{
    [Authorize]
    public class CuentasController:Controller
    {
        //Nos permite administrar y gestionar usuarios
        private readonly UserManager<UsuarioAplicacacion> gestionUsuarios;
        //Contiene los metodos necesarios para que el user inicie sesion
        private readonly SignInManager<UsuarioAplicacacion> gestionLogin;


        public CuentasController(UserManager<UsuarioAplicacacion> gestionUsuarios, SignInManager<UsuarioAplicacacion> gestionLogin)
        {
            this.gestionUsuarios = gestionUsuarios;
            this.gestionLogin = gestionLogin;

        }

        [HttpGet]
        [Route("Cuentas/Registro")]
        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroModelo model)
        {
            if (ModelState.IsValid)
            {
                var user = new UsuarioAplicacacion
                {
                    UserName = model.Email,
                    Email = model.Email,
                    ayudaPass = model.ayudaPass
                };

                //Se guarda la data del usuario en la tabla de base de datos AspNetUser
                var resultado = await gestionUsuarios.CreateAsync(user, model.Password);

                //si el usuario se creo correctamente se logea y se redirige al inicio
                if (resultado.Succeeded)
                {
                    if (gestionLogin.IsSignedIn(User) && User.IsInRole("Administracion"))
                    {
                        return RedirectToAction("ListarUsuarios", "Administracion");
                    }

                    await gestionLogin.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                //control del erroe en caso de que se produzca
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    
        [HttpGet]
        [Route("Cuentas/Login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }  
        
        [HttpPost]
        [Route("Cuentas/CerrarSesion")]
        public async Task<IActionResult>CerrarSesion()
        {
            await gestionLogin.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        [HttpPost]
        [Route("Cuentas/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await gestionLogin.PasswordSignInAsync(
                    model.Email, model.Password, model.Recuerdame, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesion no valido");
            }
            return View(model);
        }

        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        [Route("Cuents/comprobarEmail")]
        public async Task<IActionResult> ComprobarEmail(string email)
        {
            var user = await gestionUsuarios.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"El email {email} no esta disponible");
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Cuentas/AccesoDenegado")]
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }

}
