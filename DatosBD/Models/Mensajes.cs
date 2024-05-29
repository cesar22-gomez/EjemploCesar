using System;
using System.Collections.Generic;

namespace DatosBD.Models;

public partial class Mensajes
{
    public int MensajeId { get; set; }

    public int? ClienteId { get; set; }

    public string? Mensaje { get; set; }

    public virtual Clientes? Cliente { get; set; }
}
