using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Clientes
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Identificacion { get; set; }

    public string? Nacionalidad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Provincia { get; set; }

    public string? Canton { get; set; }

    public string? Distrito { get; set; }

    public string? Barrio { get; set; }

    public string? DireccionExacta { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? TarjetaTipo { get; set; }

    public string? NumeroTarjeta { get; set; }

    public string? MarcaTarjeta { get; set; }

    public string? Estado { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasena { get; set; }

    public virtual ICollection<Mensajes> Mensajes { get; set; } = new List<Mensajes>();

    public virtual ICollection<OrdenesCompra> OrdenesCompra { get; set; } = new List<OrdenesCompra>();
}
