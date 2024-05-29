using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Presentacion { get; set; }

    public string? Tamano { get; set; }

    public double? Peso { get; set; }

    public double? Precio { get; set; }

    public int? CantMinimaInventario { get; set; }

    public int? CantMaximaBodega { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetallesOrden> DetallesOrdens { get; set; } = new List<DetallesOrden>();

    public virtual ICollection<EntradasProducto> EntradasProductos { get; set; } = new List<EntradasProducto>();
}
