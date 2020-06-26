using Ejemplo1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Controllers
{
    [Authorize(Roles = "Administracion")]
    public class AdministracionController : Controller
    {
        private readonly RoleManager<IdentityRole> gestionRoles;
        private readonly UserManager<UsuarioAplicacacion> gestionUsuarios;

        public AdministracionController(RoleManager<IdentityRole> gestionroles, UserManager<UsuarioAplicacacion> gestionUsuarios)
        {
            this.gestionRoles = gestionroles;
            this.gestionUsuarios = gestionUsuarios;
        }

        [HttpGet]
        [Route("Administracion/CrearRol")]
        public IActionResult CrearRol()
        {
            return View();
        }

        [HttpPost]
        [Route("Administracion/CrearRol")]
        public async Task<IActionResult> CrearRol(CrearRolViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityrole = new IdentityRole
                {
                    Name = model.NombreRol
                };

                IdentityResult result = await gestionRoles.CreateAsync(identityrole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            } 
            return View(model);
        }

        [HttpGet]
        [Route("Administracion/Roles")]
        public IActionResult ListarRoles()
        {
            var roles = gestionRoles.Roles;
            return View(roles);
        }


        [HttpGet]
        [Route("Administracion/EditarRol")]
        public async Task<IActionResult> EditarRol(string id)
        {
            //buscar el rol por id
            var rol = await gestionRoles.FindByIdAsync(id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {id} no fue encontrado";
                return View("Error");
            }

            var model = new EditarRolViewModel
            {
                Id = rol.Id,
                nombreRol = rol.Name
            };

            //obtenermos todos los usuarios por rol

            foreach (var usuario in gestionUsuarios.Users)
            {
                if (await gestionUsuarios.IsInRoleAsync(usuario,rol.Name))
                {
                    model.Usuarios.Add(usuario.UserName);
                }
                
            }

            return View(model);
        }


        [HttpPost]
        [Route("Administracion/EditarRol")]
        public async Task<IActionResult> EditarRol(EditarRolViewModel modelo)
        {
            var rol = await gestionRoles.FindByIdAsync(modelo.Id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {modelo.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                rol.Name = modelo.nombreRol;
                var resultado = await gestionRoles.UpdateAsync(rol);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListarRoles");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
                   return View(modelo);
        }

        [HttpGet]
        [Route("Administracion/EditarRolUsuario")]
        public async Task<IActionResult> EditarRolUsuario(string rolId)
        {
            ViewBag.roleId = rolId;

            var rol = await gestionRoles.FindByIdAsync(rolId);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {rolId} no fue encontrado";
                return View("Error");
            }
            var model = new List<UsuarioRolModelo>();

            foreach (var user in gestionUsuarios.Users)
            {
                var usuarioRolModelo = new UsuarioRolModelo
                {
                    UsuarioId = user.Id,
                    UsuarioNombre = user.UserName
                };

                if (await gestionUsuarios.IsInRoleAsync(user,rol.Name))
                {
                    usuarioRolModelo.EstadoSeleccionado = true;
                }
                else
                {
                    usuarioRolModelo.EstadoSeleccionado = true;
                }

                model.Add(usuarioRolModelo);
            }

            
            return View(model);
        }

        [HttpPost]
        [Route("Administracion/EditarRolUsuario")]
        public async Task<IActionResult> EditarRolUsuario(List<UsuarioRolModelo> model, string rolId)
        {
            var rol = await gestionRoles.FindByIdAsync(rolId);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {rolId} no fue encontrado";
                return View("Error");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await gestionUsuarios.FindByIdAsync(model[i].UsuarioId);
                IdentityResult result = null;

                if (model[i].EstadoSeleccionado && !(await gestionUsuarios.IsInRoleAsync(user,rol.Name)))
                {
                    result = await gestionUsuarios.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].EstadoSeleccionado && await gestionUsuarios.IsInRoleAsync(user, rol.Name))
                {
                    result = await gestionUsuarios.RemoveFromRoleAsync(user, rol.Name);

                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i<(model.Count-1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditarRol", new { Id = rolId });
                    }
                }

            }

            return RedirectToAction("EditarRol", new { Id = rolId });
        }


        [HttpGet]
        [Route("Administracion/ListadoUsuarios")]
        public IActionResult ListadoUsuarios()
        {
            var usuarios = gestionUsuarios.Users;
            return View(usuarios);
        }

        [HttpGet]
        [Route("Administracion/EditarUsuarios")]
        public async Task<IActionResult> EditarUsuarios(string id)
        {
           
            var usuario = await gestionUsuarios.FindByIdAsync(id);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"usuario con el ID = {id} no fue encontrado";
                return View("Error");
            }

            var usuarioClaims = await gestionUsuarios.GetClaimsAsync(usuario);
            var usuarioRoles = await gestionUsuarios.GetRolesAsync(usuario);


            var model = new EditarUsuarioModelo
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.UserName,
                ayudaPass = usuario.ayudaPass,
                Notificaciones = usuarioClaims.Select(c => c.Value).ToList(),
                Roles = usuarioRoles
            };



            return View(model);
        }

        [HttpPost]
        [Route("Administracion/EditarUsuarios")]
        public async Task<IActionResult> EditarUsuarios(EditarUsuarioModelo model)
        {
            var usuario = await gestionUsuarios.FindByIdAsync(model.Id);

            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"usuario con el ID = {model.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                usuario.Email = model.Email;
                usuario.UserName = model.NombreUsuario;
                usuario.ayudaPass = model.ayudaPass;

                var resultado = await gestionUsuarios.UpdateAsync(usuario);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListadoUsuarios");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }
        

        [HttpPost]
        [Route("Administracion/BorrarUsuario")]
        public async Task<IActionResult> BorrarUsuario(string id)
        {
            var user = await gestionUsuarios.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con id = {id} no fue encontrado";
                return View("Error");
            }

            var resultado = await gestionUsuarios.DeleteAsync(user);

            if (resultado.Succeeded)
            {
                return RedirectToAction("ListadoUsuarios");
            }

            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

            return View("ListadoUsuarios");

        }


        [HttpPost]
        [Route("Administracion/BorrarRol")]
        public async Task<IActionResult> BorrarRol(string id)
        {
            var user = await gestionRoles.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con rol = {id} no fue encontrado";
                return View("Error");
            }

            var resultado = await gestionRoles.DeleteAsync(user);

            if (resultado.Succeeded)
            {
                return RedirectToAction("ListarRoles");
            }

            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("ListarRoles");

        }

    }
}
