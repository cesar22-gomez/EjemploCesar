using System;
using System.Data;
using System.Linq;
using DatosBD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatosBD
{
    public class Metodos
    {
        private readonly Proyecto1BdContext _context;

        public Metodos(Proyecto1BdContext context)
        {
            _context = context;
        }

        #region Login
        public async Task<(string TipoUsuario, int Resultado)> AutenticarUsuarioAsync(string usuario, string contrasena)
        {
            var tipoUsuarioParam = new SqlParameter("@TipoUsuario", SqlDbType.VarChar, 12)
            {
                Direction = ParameterDirection.Output
            };

            var resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC AutenticarUsuario @Usuario, @Contrasena, @TipoUsuario OUTPUT, @Resultado OUTPUT",
                new SqlParameter("@Usuario", usuario),
                new SqlParameter("@Contrasena", contrasena),
                tipoUsuarioParam,
                resultadoParam);

            var tipoUsuario = tipoUsuarioParam.Value?.ToString() ?? "";
            var resultado = Convert.ToInt32(resultadoParam.Value);

            // Corregir la interpretación del resultado
            // Si el resultado es diferente de 0, se devuelve un mensaje de error
            if (resultado != 0)
            {
                tipoUsuario = ""; // Limpiar el tipo de usuario en caso de error
            }

            return (tipoUsuario, resultado);
        }
        #endregion

        #region Registro Cliente

        public async Task<int> RegistrarClienteAsync(
            string nombre, string apellidoPaterno, string apellidoMaterno, string identificacion,
            string nacionalidad, DateOnly fechaNacimiento, string provincia, string canton,
            string distrito, string barrio, string direccionExacta, string telefono1, string telefono2,
            string tarjetaTipo, string numeroTarjeta, string marcaTarjeta, string usuario, string contrasena)
        {
            int resultado = 0;

            try
            {
                var nombreParam = new SqlParameter("@Nombre", SqlDbType.VarChar, 50)
                {
                    Value = nombre
                };

                var apellidoPaternoParam = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar, 30)
                {
                    Value = apellidoPaterno
                };

                var apellidoMaternoParam = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar, 30)
                {
                    Value = apellidoMaterno
                };

                var identificacionParam = new SqlParameter("@Identificacion", SqlDbType.VarChar, 12)
                {
                    Value = identificacion
                };

                var nacionalidadParam = new SqlParameter("@Nacionalidad", SqlDbType.VarChar, 25)
                {
                    Value = nacionalidad
                };

                var fechaNacimientoParam = new SqlParameter("@FechaNacimiento", SqlDbType.Date)
                {
                    Value = fechaNacimiento
                };

                var provinciaParam = new SqlParameter("@Provincia", SqlDbType.VarChar, 20)
                {
                    Value = provincia
                };

                var cantonParam = new SqlParameter("@Canton", SqlDbType.VarChar, 25)
                {
                    Value = canton
                };

                var distritoParam = new SqlParameter("@Distrito", SqlDbType.VarChar, 25)
                {
                    Value = distrito
                };

                var barrioParam = new SqlParameter("@Barrio", SqlDbType.VarChar, 30)
                {
                    Value = barrio
                };

                var direccionExactaParam = new SqlParameter("@DireccionExacta", SqlDbType.VarChar, 100)
                {
                    Value = direccionExacta
                };

                var telefono1Param = new SqlParameter("@Telefono1", SqlDbType.VarChar, 12)
                {
                    Value = telefono1
                };

                var telefono2Param = new SqlParameter("@Telefono2", SqlDbType.VarChar, 12)
                {
                    Value = telefono2
                };

                var tarjetaTipoParam = new SqlParameter("@TarjetaTipo", SqlDbType.VarChar, 12)
                {
                    Value = tarjetaTipo
                };

                var numeroTarjetaParam = new SqlParameter("@NumeroTarjeta", SqlDbType.VarChar, 25)
                {
                    Value = numeroTarjeta
                };

                var marcaTarjetaParam = new SqlParameter("@MarcaTarjeta", SqlDbType.VarChar, 20)
                {
                    Value = marcaTarjeta
                };

                var usuarioParam = new SqlParameter("@Usuario", SqlDbType.VarChar, 50)
                {
                    Value = usuario
                };

                var contrasenaParam = new SqlParameter("@Contrasena", SqlDbType.VarChar, 30)
                {
                    Value = contrasena
                };

                var resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC RegistrarCliente @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Identificacion, @Nacionalidad, @FechaNacimiento, @Provincia, @Canton, @Distrito, @Barrio, @DireccionExacta, @Telefono1, @Telefono2, @TarjetaTipo, @NumeroTarjeta, @MarcaTarjeta, @Usuario, @Contrasena, @Resultado OUTPUT",
                    nombreParam, apellidoPaternoParam, apellidoMaternoParam, identificacionParam,
                    nacionalidadParam, fechaNacimientoParam, provinciaParam, cantonParam,
                    distritoParam, barrioParam, direccionExactaParam, telefono1Param, telefono2Param,
                    tarjetaTipoParam, numeroTarjetaParam, marcaTarjetaParam, usuarioParam, contrasenaParam,
                    resultadoParam
                );

                // Obtener el valor del parámetro de salida
                resultado = (int)resultadoParam.Value;
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                Console.WriteLine("Error al registrar cliente: " + ex.Message);
                throw;
            }

            return resultado;
        }

        #endregion

        #region Productos

        //Obetener catalogo de productos para clientes
        public async Task<List<Productos>> ObtenerProductosParaCatalogoAsync()
        {
            var productos = await _context.Productos
                .FromSqlRaw("EXEC ObtenerProductosParaCatalogo")
                .ToListAsync();

            return productos;
        }

        //Obtener catalogo de productos para empleados
        public async Task<List<Productos2>> ObtenerProductosParaEmpleadosAsync()
        {
            var productos2 = await _context.Productos2
                .FromSqlRaw("EXEC ObtenerProductosParaEmpleados")
                .ToListAsync();

            return productos2;
        }

        //Actualizar Producto

        public async Task<int> ActualizarProductoAsync(
            int productoId, string nombre, string presentacion, string tamano, double peso,
            double precio, int stock, int cantMinimaInventario, int cantMaximaBodega,
            int categoriaId)
        {
            int resultado = 0;

            try
            {
                var productoIdParam = new SqlParameter("@ProductoID", SqlDbType.Int)
                {
                    Value = productoId
                };

                var nombreParam = new SqlParameter("@Nombre", SqlDbType.VarChar, 50)
                {
                    Value = nombre
                };

                var presentacionParam = new SqlParameter("@Presentacion", SqlDbType.VarChar, 30)
                {
                    Value = presentacion
                };

                var tamanoParam = new SqlParameter("@Tamano", SqlDbType.VarChar, 25)
                {
                    Value = tamano
                };

                var pesoParam = new SqlParameter("@Peso", SqlDbType.Float)
                {
                    Value = peso
                };

                var precioParam = new SqlParameter("@Precio", SqlDbType.Float)
                {
                    Value = precio
                };

                var stockParam = new SqlParameter("@Stock", SqlDbType.Int)
                {
                    Value = stock
                };

                var cantMinimaInventarioParam = new SqlParameter("@CantMinimaInventario", SqlDbType.Int)
                {
                    Value = cantMinimaInventario
                };

                var cantMaximaBodegaParam = new SqlParameter("@CantMaximaBodega", SqlDbType.Int)
                {
                    Value = cantMaximaBodega
                };

                var categoriaIdParam = new SqlParameter("@CategoriaID", SqlDbType.Int)
                {
                    Value = categoriaId
                };

                var resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC ActualizarProducto @ProductoID, @Nombre, @Presentacion, @Tamano, @Peso, @Precio, @Stock, @CantMinimaInventario, @CantMaximaBodega, @CategoriaID, @Resultado OUTPUT",
                    productoIdParam, nombreParam, presentacionParam, tamanoParam, pesoParam,
                    precioParam, stockParam, cantMinimaInventarioParam, cantMaximaBodegaParam,
                    categoriaIdParam, resultadoParam
                );

                // Obtener el valor del parámetro de salida
                resultado = (int)resultadoParam.Value;
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                Console.WriteLine("Error al actualizar producto: " + ex.Message);
                throw;
            }

            return resultado;
        }

        //Obtener producto por ID

        public async Task<Productos> ObtenerInformacionProductoAsync(int productoId)
        {
            try
            {
                var producto = await _context.Productos
                    .Where(p => p.ProductoId == productoId)
                    .FirstOrDefaultAsync();

                return producto;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la información del producto: " + ex.Message);
                throw;
            }
        }
        #endregion
    }
}
