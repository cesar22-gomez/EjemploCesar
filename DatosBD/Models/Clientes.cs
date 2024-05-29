using System;
using System.Collections.Generic;

namespace DatosBD.Models;

public partial class Clientes
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Provincia { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public string Distrito { get; set; } = null!;

    public string Barrio { get; set; } = null!;

    public string DireccionExacta { get; set; } = null!;

    public string Telefono1 { get; set; } = null!;

    public string Telefono2 { get; set; } = null!;

    public string TarjetaTipo { get; set; } = null!;

    public string NumeroTarjeta { get; set; } = null!;

    public string MarcaTarjeta { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateTime? UltimaActualizacion { get; set; }

    public virtual ICollection<Mensajes> Mensajes { get; set; } = new List<Mensajes>();

    public virtual ICollection<OrdenesCompra> OrdenesCompra { get; set; } = new List<OrdenesCompra>();
}
