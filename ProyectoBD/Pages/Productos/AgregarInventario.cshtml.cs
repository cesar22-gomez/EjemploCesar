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
                // Llama al método en la capa de Negocio para obtener la información del producto
                Producto = await _producto.ObtenerInformacionProducto(id);

                // Si el producto no se encuentra, redirige a la página de mantenimiento de productos
                if (Producto == null)
                {
                    return RedirectToPage("/Productos/Pages_Productos_MantenimientoProductos");
                }

                return Page(); // Devuelve la página con la información del producto
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí si es necesario
                Console.WriteLine("Error al obtener la información del producto: " + ex.Message);
                throw; // Lanza la excepción para que se maneje en la capa superior si es necesario
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
        //                TempData["SuccessMessage"] = "El stock del producto se actualizó correctamente.";
        //                return RedirectToPage("/Productos/MantenimientoProductos"); // Página de inicio o cualquier otra página de tu elección
        //            case -1:
        //                ModelState.AddModelError("", "Error al actualizar el stock");

        //                break;
        //        }
        //    }
        //    return Page();
        //}
    }
}

