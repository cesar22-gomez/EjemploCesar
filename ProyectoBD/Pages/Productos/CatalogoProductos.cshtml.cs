using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using DatosBD.Models;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DatosBD;

namespace ProyectoBD.Pages.Productos
{
    public class CatalogoProductosModel : PageModel
    {
        private readonly Negocio.Producto _producto;

        public List<DatosBD.Models.Productos> ListaProductos { get; set; } // Almacenará los productos

        [BindProperty]
        public DatosBD.Models.Productos Productos { get; set; }

        public CatalogoProductosModel(Proyecto1BdContext context)
        {
            _producto = new Negocio.Producto(new Metodos(context));
        }
        public string SuccessMessage { get; private set; }
        public async Task OnGetAsync() // Cambia el nombre a OnGetAsync y marca el método como async
        {
            SuccessMessage = TempData["SuccessMessage"] as string;
            ListaProductos = await _producto.ObtenerProductosParaCatalogo(); // Carga la lista de productos asincrónicamente
        }

    }
}
