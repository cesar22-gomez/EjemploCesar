using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Identificacion { get; set; }

    public string? Nacionalidad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string Usuario { get; set; } = null!;

    public string? Contrasena { get; set; }

    public virtual Logueo? Logueo { get; set; }
}
