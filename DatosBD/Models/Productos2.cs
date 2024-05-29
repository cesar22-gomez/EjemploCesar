﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosBD.Models
{
    public partial class Productos2
    {
        [Key]
        public int ProductoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Presentacion { get; set; } = null!;

        public string Tamano { get; set; } = null!;

        public double Peso { get; set; }

        public double Precio { get; set; }

        public int Stock { get; set; }

        public int CantMinimaInventario { get; set; }

        public int CantMaximaBodega { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categorias Categoria { get; set; } = null!;

        public virtual ICollection<DetallesOrden> DetallesOrden { get; set; } = new List<DetallesOrden>();

        public virtual ICollection<EntradasProductos> EntradasProductos { get; set; } = new List<EntradasProductos>();
    }
}
