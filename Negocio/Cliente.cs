using System;
using System.Text.RegularExpressions;
using DatosBD;
using DatosBD.Models;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente
    {
        private readonly Metodos _metodos;

        public Cliente(Metodos metodos)
        {
            _metodos = metodos;
        }

        public async Task<int> RegistrarCliente(
            string nombre, string apellidoPaterno, string apellidoMaterno, string identificacion,
            string nacionalidad, DateOnly fechaNacimiento, string provincia, string canton,
            string distrito, string barrio, string direccionExacta, string telefono1, string telefono2,
            string tarjetaTipo, string numeroTarjeta, string marcaTarjeta, string usuario, string contrasena)
        {
            int resultadoRegistro = 0;

            try
            {
                ValidarRegistroCliente(nombre, apellidoPaterno, apellidoMaterno, identificacion,
                    nacionalidad, fechaNacimiento, provincia, canton,
                    distrito, barrio, direccionExacta, telefono1, telefono2,
                    tarjetaTipo, numeroTarjeta, marcaTarjeta, usuario, contrasena);
                // Llama al método de la capa de datos para registrar al cliente
                resultadoRegistro = await _metodos.RegistrarClienteAsync(
                    nombre, apellidoPaterno, apellidoMaterno, identificacion,
                    nacionalidad, fechaNacimiento, provincia, canton,
                    distrito, barrio, direccionExacta, telefono1, telefono2,
                    tarjetaTipo, numeroTarjeta, marcaTarjeta, usuario, contrasena
                );

                // Devuelve el resultado obtenido del registro del cliente
                return resultadoRegistro;
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí si es necesario
                Console.WriteLine("Error al registrar cliente: " + ex.Message);
                throw; // Lanza la excepción para que se maneje en la capa superior si es necesario
            }
        }


        public void ValidarRegistroCliente(
            string nombre, string apellidoPaterno, string apellidoMaterno, string identificacion,
            string nacionalidad, DateOnly fechaNacimiento, string provincia, string canton,
            string distrito, string barrio, string direccionExacta, string telefono1, string telefono2,
            string tarjetaTipo, string numeroTarjeta, string marcaTarjeta, string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es obligatorio.");
            }

            if (!nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                throw new ArgumentException("El nombre solo debe contener letras y espacios.");
            }

            if (string.IsNullOrWhiteSpace(apellidoPaterno))
            {
                throw new ArgumentException("El apellido paterno es obligatorio.");
            }

            if (!apellidoPaterno.All(char.IsLetter))
            {
                throw new ArgumentException("El apellido paterno solo debe contener letras.");
            }

            if (string.IsNullOrWhiteSpace(apellidoMaterno))
            {
                throw new ArgumentException("El apellido materno es obligatorio.");
            }

            if (!apellidoMaterno.All(char.IsLetter))
            {
                throw new ArgumentException("El apellido materno solo debe contener letras.");
            }

            if (string.IsNullOrWhiteSpace(identificacion))
            {
                throw new ArgumentException("La identificación es obligatoria.");
            }

            if (identificacion.Length != 9 || !identificacion.All(char.IsDigit))
            {
                throw new ArgumentException("La identificación debe ser un número de 9 dígitos.");
            }

            if (string.IsNullOrWhiteSpace(nacionalidad))
            {
                throw new ArgumentException("La nacionalidad es obligatoria.");
            }

            if (!nacionalidad.All(char.IsLetter))
            {
                throw new ArgumentException("La nacionalidad solo debe contener letras.");
            }

            // Obtener la fecha actual en formato DateOnly
            DateOnly fechaActual = DateOnly.FromDateTime(DateTime.Now);

            // Validación de la fecha de nacimiento en el formato correcto
            if (fechaNacimiento > fechaActual || fechaNacimiento < DateOnly.Parse("1900-01-01"))
            {
                throw new ArgumentException("Debe seleccionar una fecha con un formato válido.");
            }

            if (string.IsNullOrWhiteSpace(provincia))
            {
                throw new ArgumentException("La provincia es obligatoria.");
            }

            if (!provincia.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                throw new ArgumentException("La provincia solo debe contener letras y espacios.");
            }

            if (string.IsNullOrWhiteSpace(canton))
            {
                throw new ArgumentException("El canton es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(distrito))
            {
                throw new ArgumentException("El distrito es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(barrio))
            {
                throw new ArgumentException("El barrio es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(direccionExacta))
            {
                throw new ArgumentException("La dirección exacta es obligatoria.");
            }

            // Validación de teléfonos
            if (string.IsNullOrWhiteSpace(telefono1) || string.IsNullOrWhiteSpace(telefono2))
            {
                throw new ArgumentException("Los teléfonos son obligatorios.");
            }

            if (telefono1.Length != 8 || telefono2.Length != 8 || !telefono1.All(char.IsDigit) || !telefono2.All(char.IsDigit))
            {
                throw new ArgumentException("Los teléfonos deben tener 8 dígitos y solo contener números.");
            }

            // Validación de tarjeta de crédito
            if (string.IsNullOrWhiteSpace(tarjetaTipo))
            {
                throw new ArgumentException("El tipo de tarjeta es obligatorio.");
            }

            if (!tarjetaTipo.All(char.IsLetter))
            {
                throw new ArgumentException("El tipo de tarjeta solo debe contener letras.");
            }

            if (string.IsNullOrWhiteSpace(numeroTarjeta))
            {
                throw new ArgumentException("El número de tarjeta es obligatorio.");
            }

            if (numeroTarjeta.Length != 16 || !numeroTarjeta.All(char.IsDigit))
            {
                throw new ArgumentException("El número de tarjeta debe ser un número de 16 dígitos.");
            }

            if (string.IsNullOrWhiteSpace(marcaTarjeta))
            {
                throw new ArgumentException("La marca de tarjeta es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(usuario))
            {
                throw new ArgumentException("El usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }
        }

    }


}
