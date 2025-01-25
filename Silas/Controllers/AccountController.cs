using Microsoft.AspNetCore.Mvc;
using Silas.Models.Usuarios;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace Silas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _usuarioService;

        public AccountController(UserService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            //validamos las credenciales del lgoin 
            UserValidatorResponse response = await _usuarioService.CheckUserCredentials(username, password);

            if (response.category == "student" || response.category == "company" )
            {
                ViewBag.UserRole = response.category;
                ViewBag.userId = response.id;
            // Tras loguear, REDIRIGIMOS A GENERIC
                return View("Generic");
            }
            else if (response.category  == "Credentials Error")
            {
                //  SI CREDENCIALES ERRONEA RETURN A LOGIN DE NUEVO
                ViewBag.Mensaje = "Credenciales Erroneas";
            }
                //  SI CREDENCIALES ERRONEA RETURN A LOGIN DE NUEVO
                return View("Login");
            
        }


        // EJEMPLO: Acción GET “Generic”:
   
        public IActionResult Generic()
        {
            // ESTOY FORZANDO EL ROL MANUAL DE MOMENTO, ESTÁ SIN FUNCIONALIDAD
            ViewBag.UserRole = "Admin"; // "Alumno/Empresa"

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        // REGISTRO
        [HttpPost]
        public async Task<IActionResult> Register(User usuario)
        {
            ViewBag.Mensaje = "Usuario creado con exito " + usuario.email;

            if (ModelState.IsValid)
            {
                var resultado = await _usuarioService.AsyncCreateUser(usuario);
                if (resultado == 0)
                {
                    ViewBag.Mensaje = "Usuario creado con exito";
                }
                else if ( resultado == 1)
                {
                    ViewBag.Mensaje = "Error al registrar usuario";
                }
                else
                {
                    ViewBag.Mensaje = "Email ya esta registrado";
                }
            }
            return View();
        }
    }
}
