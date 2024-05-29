using System;
using System.Text.RegularExpressions;
using DatosBD;
using DatosBD.Models;
using System.Threading.Tasks;

namespace Negocio
{
    public class InicioDeSesion
    {
        private readonly Metodos _metodos;

        public InicioDeSesion(Metodos metodos)
        {
            _metodos = metodos;
        }

        public async Task<string?> AutenticarUsuario(string usuario, string contrasena)
        {
            ValidarInicioSesion(usuario, contrasena);

            // Llamar al método de la capa de datos para autenticar al usuario
            var (tipoUsuario, resultado) = await _metodos.AutenticarUsuarioAsync(usuario, contrasena);

            // Verificar el resultado de la autenticación
            switch (resultado)
            {
                case 0:
                    // Autenticación exitosa, se devuelve el tipo de usuario
                    return tipoUsuario;
                case 1:
                    // Error en la autenticación
                    return null;
                default:
                    // Credenciales incorrectas o usuario no existe
                    return null;
            }
        }


        public void ValidarInicioSesion(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }
        }
    }
}

