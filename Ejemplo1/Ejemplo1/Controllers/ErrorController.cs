using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo1.Controllers
{
    public class ErrorController:Controller
    {
        private readonly ILogger<ErrorController> logs;
        public ErrorController(ILogger<ErrorController> log)
        {
            this.logs = log;
        }
        //[Route("Error/{statusCode}")]
        //public IActionResult HttpStatusCodeHandler(int statusCode)
        //{
        //    switch (statusCode)
        //    {
        //        case 404:
        //            ViewBag.ErrorMessage = "El recurso solicitado no existe";
        //            break;
        //    }
        //    return View("Error");
        //}

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exception.Path;
            ViewBag.ExceptionMessage = exception.Error.Message;
            ViewBag.StackTrace = exception.Error.StackTrace;

            logs.LogError($"Ruta del Error: {exception.Path}"+
                          $"Excepcion: {exception.Error}"+
                          $"Traza del Error: {exception.Error.StackTrace }");

            return View("ErrorGenerico");
        }
    }
}
