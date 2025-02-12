﻿using Microsoft.AspNetCore.Mvc;
using Silas.Models.Usuarios;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Silas.Models.Companies;
using Silas.Models.Offers;

namespace Silas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _usuarioService;


        public AccountController(UserService usuarioService) //INYECTO EL SERVICIO DE LA COMPAÑÍA TAMBIÉN Y LA INSTANCIO PARA TRABAJAR CON ELLA
            //Y LLAMARLA EN LA ´FUNCIÓN LOGIN ANTES DE CARGAR "_GenericLayout"
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

            //IMPORTANTE!!!!!!!!!!!!!!!!!!!!!!!!!!1
            //NECESITAMOS EVALUAR EN ESTA VISTA, SI EL STATUS DEL USER QUE RECIBIMOS ES 0, O 1, EN CASO DE SER 0
            //NOS LLEVA A UN VIEW DE ERROR, EN CASO DE SER 1 PROCEDEMOS NORMALMENTE
            
            

            if (response.category == "student" || response.category == "company" || response.category == "admin")
            {
               
                if(response.user_status == 0)
                {
                    return View("InactiveAccount");
                }

                return View("_GenericLayout", response);

             
            }
            else if (response.category == "Credentials error")
            {

                ViewBag.Mensaje = "Credenciales incorrectas";
            }
            // Si las credenciales son erróneas, retornar a la vista de login (ARREGLAR USUARIO DE EMPRESA, POR ALGUNA RAZON VA AQUÍ)
            return View("Login");
        }


        // EJEMPLO: Acción GET “Generic”:





        public async Task<IActionResult>  _GenericLayout( int userId)
        {
            // ESTOY FORZANDO EL ROL MANUAL DE MOMENTO, ESTÁ SIN FUNCIONALIDAD
            

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
        //LOGOUT
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpia la sesión si es necesario
                                         // Si usas autenticación, puedes hacer:
                                         // await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
