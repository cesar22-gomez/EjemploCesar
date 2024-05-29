﻿using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
