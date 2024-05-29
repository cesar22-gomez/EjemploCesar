using DatosBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosBD
{
    public class DbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Proyecto1BdContext CreateDbContext(string userType)
        {
            var connectionStringName = userType switch
            {
                "Cliente" => "ClienteConexion",
                "Administrador" => "AdminConexion",
                "Empleado" => "EmpleadoConexion",
                _ => "DefaultConexion"
            };

            var connectionString = _configuration.GetConnectionString(connectionStringName);
            var optionsBuilder = new DbContextOptionsBuilder<Proyecto1BdContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new Proyecto1BdContext(optionsBuilder.Options);
        }
    }

}
