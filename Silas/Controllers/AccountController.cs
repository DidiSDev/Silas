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

        public IActionResult Register()
        {

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }


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
