using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using DatosBD.Models;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DatosBD;

namespace ProyectoBD.Pages.InicioDeSesion
{
    public class LoginModel : PageModel
    {
        private readonly Negocio.InicioDeSesion _inicioDeSesion;

        [BindProperty]
        public DatosBD.Models.Logueo Logueo { get; set; }

        public LoginModel(Proyecto1BdContext context)
        {
            _inicioDeSesion = new Negocio.InicioDeSesion(new Metodos(context));
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // L�gica para iniciar sesi�n utilizando la instancia _inicioDeSesion
                var usuario = Logueo.Usuario;
                var contrasena = Logueo.Contrasena;

                var tipoUsuario = _inicioDeSesion.AutenticarUsuario(usuario, contrasena).Result;

                if (tipoUsuario == "Cliente")
                {
                    // Redirigir a la p�gina correspondiente si el inicio de sesi�n es exitoso
                    return RedirectToPage("/Productos/CatalogoProductos");
                }
                else if (tipoUsuario == "Empleado")
                {
                    // Redirigir a la p�gina correspondiente si el inicio de sesi�n es exitoso
                    return RedirectToPage("/Productos/MantenimientoProductos");
                }
                else
                {
                    // Si las credenciales son incorrectas o el usuario no existe, agregar un mensaje de error al ModelState
                    ModelState.AddModelError("", "Credenciales incorrectos o usuario inactivo.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepci�n que pueda ocurrir durante el inicio de sesi�n
                ModelState.AddModelError("", "Error al iniciar sesi�n: " + ex.Message);
                return Page();
            }
        }

    }
}
