﻿using System;
using System.Collections.Generic;

namespace Datos.Models;

public partial class Logueo
{
    public int Id { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasena { get; set; }

    public string? Tipo { get; set; }
}
