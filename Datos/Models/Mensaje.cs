using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Mensaje
{
    public int MensajeId { get; set; }

    public int? ClienteId { get; set; }

    public string? Mensaje1 { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
