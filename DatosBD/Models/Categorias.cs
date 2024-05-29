using System;
using System.Collections.Generic;

namespace DatosBD.Models;

public partial class Categorias
{
    public int CategoriaId { get; set; }

    public string? NombreCategoria { get; set; }

    public DateTime? UltimaActualizacion { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
