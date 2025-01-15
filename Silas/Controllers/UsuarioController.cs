using Microsoft.AspNetCore.Mvc;
using Silas.Models.Usuarios;

namespace Silas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
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
