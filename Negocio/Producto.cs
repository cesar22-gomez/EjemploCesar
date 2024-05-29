using System;
using System.Text.RegularExpressions;
using DatosBD;
using DatosBD.Models;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        private readonly Metodos _metodos;

        public Producto(Metodos metodos)
        {
            _metodos = metodos;
        }

        //Obetener catalogo de productos para clientes
        public async Task<List<Productos>> ObtenerProductosParaCatalogo()
        {
            // Llamar al método en la capa DatosBD
            return await _metodos.ObtenerProductosParaCatalogoAsync();
        }

        //Obtener catalogo de productos para empleados
        public async Task<List<Productos2>> ObtenerProductosParaEmpleados()
        {
            // Llamar al método en la capa DatosBD
            return await _metodos.ObtenerProductosParaEmpleadosAsync();
        }

        public async Task<int> ActualizarProducto(
            int productoId, string nombre, string presentacion, string tamano, double peso,
            double precio, int stock, int cantMinimaInventario, int cantMaximaBodega,
            int categoriaId)
        {
            int resultadoActualizacion = 0;

            try
            {
                // Validar los datos del producto si es necesario
                ValidarProducto(stock);

                // Llamar al método de la capa DatosBD para actualizar el producto
                resultadoActualizacion = await _metodos.ActualizarProductoAsync(
                    productoId, nombre, presentacion, tamano, peso, precio, stock,
                    cantMinimaInventario, cantMaximaBodega, categoriaId
                );

                // Devolver el resultado obtenido de la actualización del producto
                return resultadoActualizacion;
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí si es necesario
                Console.WriteLine("Error al actualizar el stock del producto: " + ex.Message);
                throw; // Lanza la excepción para que se maneje en la capa superior si es necesario
            }
        }

        //Valida Stock
        public void ValidarProducto(int stock)
        {
            if (stock <= 0)
            {
                throw new ArgumentException("El stock debe ser mayor que cero.");
            }
        }

        //Obtener producto por ID
        public async Task<Productos> ObtenerInformacionProducto(int productoId)
        {
            try
            {
                // Llama al método en la capa de datos para obtener la información del producto
                var producto = await _metodos.ObtenerInformacionProductoAsync(productoId);

                // Devuelve el producto obtenido
                return producto;
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí si es necesario
                Console.WriteLine("Error al obtener la información del producto desde la capa de negocio: " + ex.Message);
                throw; // Lanza la excepción para que se maneje en la capa superior si es necesario
            }
        }

    }
}
