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
            UserValidatorResponse response = await _usuarioService.CheckUserCredentials(username, password);

            if (response.category == "student" || response.category == "company")
            {
                ViewBag.UserRole = response.category;
                ViewBag.UserName = "UN NOMBRE"; //UNO ALEATORIO DE MOMENTO

                // ESTO EN PPIO NO SE PUEDE TOCAR, TENEMOS QUE REDIRIGIR A Generic, no puedo eliminarlo ni ir a _GenericLayout porque crashea, no sé por qué,
                //Es posible que C# internamente haya aceptado Generic como el luhgar al que ir tras Login y está en la lógica oculta de C#
                return View("Generic");
            }
            else if (response.category == "Credentials error")
            {

                ViewBag.Mensaje = "Credenciales incorrectas";
            }
            // Si las credenciales son erróneas, retornar a la vista de login (ARREGLAR USUARIO DE EMPRESA, POR ALGUNA RAZON VA AQUÍ)
            return View("Login");
        }


        // EJEMPLO: Acción GET “Generic”:





        public async Task<IActionResult>  Generic( int userId)
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
