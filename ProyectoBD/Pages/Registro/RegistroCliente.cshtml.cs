using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using DatosBD.Models;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DatosBD;

namespace ProyectoBD.Pages.Registro
{
    public class RegistroClienteModel : PageModel
    {
        private readonly Negocio.Cliente _cliente;

        [BindProperty]
        public DatosBD.Models.Clientes Clientes { get; set; }

        public RegistroClienteModel(Proyecto1BdContext context)
        {
            _cliente = new Negocio.Cliente(new Metodos(context));
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                int resultado = await _cliente.RegistrarCliente(
                    Clientes.Nombre, Clientes.ApellidoPaterno, Clientes.ApellidoMaterno, Clientes.Identificacion,
                    Clientes.Nacionalidad, Clientes.FechaNacimiento, Clientes.Provincia, Clientes.Canton,
                    Clientes.Distrito, Clientes.Barrio, Clientes.DireccionExacta, Clientes.Telefono1, Clientes.Telefono2,
                    Clientes.TarjetaTipo, Clientes.NumeroTarjeta, Clientes.MarcaTarjeta, Clientes.Usuario, Clientes.Contrasena
                );

                switch (resultado)
                {
                    case 1:
                        TempData["SuccessMessage"] = "El cliente se registró correctamente.";
                        return RedirectToPage("/Registro/RegistroCliente"); // Página de inicio o cualquier otra página de tu elección
                    case -3:
                        ModelState.AddModelError("", "Uno de los números de teléfono ya está en uso.");
                        break;
                    case -2:
                        ModelState.AddModelError("", "El cliente debe ser mayor de 18 años.");
                        break;
                    case -1:
                        ModelState.AddModelError("", "El cliente ya existe en la base de datos.");
                        break;
                    default:
                        ModelState.AddModelError("", "Error desconocido al registrar el cliente.");
                        break;
                }
            }

            // Si el modelo no es válido o el registro no fue exitoso, vuelve a cargar la página
            return Page();
        }
    }
}
