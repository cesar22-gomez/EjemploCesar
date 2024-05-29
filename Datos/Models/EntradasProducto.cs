using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class EntradasProducto
{
    public int EntradaId { get; set; }

    public DateOnly? FechaEntrada { get; set; }

    public int? ProductoId { get; set; }

    public int? CantidadIngreso { get; set; }

    public virtual Producto? Producto { get; set; }
}
