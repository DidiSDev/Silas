using Microsoft.AspNetCore.Mvc;
using Silas.Models.Usuarios;

namespace Silas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public AccountController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }

        //UNA VEZ HECHO EL LOGIN, TENEMOS QUE MODULARIZAR EL TIPO DE USUARIO, TRAS EXTRAERLO DE LA BBDD
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // POR EJEMPLO SI VAMOS A HACER QUERY PARA VER SI ES EMPRESA, ADMIN O ALUMNO, CUANDO LO EXTRAIGAMOS...:
            //AHORA PARA LAS PRUEBAS LO QUE TENEMOS QUE PONER ES:
            /**
             ADMIN: admin@salesianos.com / contraseña: "la que queramos"
            ALUMNO: "lo que queramos" / "lo que queramos"
            EMPRESA: "empresa@salesianos.com" / "la que queramos"
             */

            if (username == "admin@salesianos.com")
            {
                ViewBag.UserRole = "Admin";
            }
            else if (username == "empresa@salesianos.com")
            {
                ViewBag.UserRole = "Empresa";
            }
            else
            {
                // En el else entra con cualquier usuario y contraseña inventadas 
                ViewBag.UserRole = "Alumno";
            }

            // Tras loguear, REDIRIGIMOS A GENERIC
            return View("Generic");
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
        public async Task<IActionResult> Register(Usuario usuario)
        {
            ViewBag.Mensaje = "Usuario creado con exito";

            if (ModelState.IsValid)
            {
                var resultado = await _usuarioService.CrearUsuarioAsync(usuario);
                if (resultado)
                {
                    ViewBag.Mensaje = "Usuario creado con exito";
                }
                else
                {
                    ViewBag.Mensaje = "Error al registrar usuario";
                }
            }
            return View();
        }
    }
}
