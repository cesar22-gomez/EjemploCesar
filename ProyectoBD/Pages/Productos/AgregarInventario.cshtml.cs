using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using DatosBD.Models;
using System;
using DatosBD;

namespace ProyectoBD.Pages.Productos
{
    public class AgregarInventarioModel : PageModel
    {
        private readonly Negocio.Producto _producto;

        [BindProperty]
        public DatosBD.Models.Productos Producto { get; set; }

        public AgregarInventarioModel(Proyecto1BdContext context)
        {
            _producto = new Negocio.Producto(new Metodos(context));
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                // Llama al m�todo en la capa de Negocio para obtener la informaci�n del producto
                Producto = await _producto.ObtenerInformacionProducto(id);

                // Si el producto no se encuentra, redirige a la p�gina de mantenimiento de productos
                if (Producto == null)
                {
                    return RedirectToPage("/Productos/Pages_Productos_MantenimientoProductos");
                }

                return Page(); // Devuelve la p�gina con la informaci�n del producto
            }
            catch (Exception ex)
            {
                // Maneja la excepci�n aqu� si es necesario
                Console.WriteLine("Error al obtener la informaci�n del producto: " + ex.Message);
                throw; // Lanza la excepci�n para que se maneje en la capa superior si es necesario
            }
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int resultado = await _producto.ActualizarProducto(
        //          Producto.ProductoId, Producto.Nombre, Producto.Presentacion, Producto.Tamano,
        //          Producto.Peso, Producto.Precio, Producto.Stock, Producto.CantMinimaInventario,
        //          Producto.CantMaximaBodega, Producto.CategoriaId
        //        );

        //        switch (resultado)
        //        {
        //            case 1:
        //                TempData["SuccessMessage"] = "El stock del producto se actualiz� correctamente.";
        //                return RedirectToPage("/Productos/MantenimientoProductos"); // P�gina de inicio o cualquier otra p�gina de tu elecci�n
        //            case -1:
        //                ModelState.AddModelError("", "Error al actualizar el stock");

        //                break;
        //        }
        //    }
        //    return Page();
        //}
    }
}

