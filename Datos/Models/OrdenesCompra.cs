using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class OrdenesCompra
{
    public int OrdenId { get; set; }

    public int? UsuarioId { get; set; }

    public DateOnly? FechaOrden { get; set; }

    public double? TotalCompra { get; set; }

    public double? Impuesto { get; set; }

    public double? CostoEnvio { get; set; }

    public virtual ICollection<DetallesOrden> DetallesOrden { get; set; } = new List<DetallesOrden>();

    public virtual Clientes? Usuario { get; set; }
}
