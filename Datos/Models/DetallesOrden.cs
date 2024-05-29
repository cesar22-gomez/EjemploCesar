using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class DetallesOrden
{
    public int DetalleId { get; set; }

    public int? OrdenId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public double? PrecioPorLinea { get; set; }

    public virtual OrdenesCompra? Orden { get; set; }

    public virtual Productos? Producto { get; set; }
}
