using System;
using System.Collections.Generic;

namespace PR2_WEBCORE.Models;

public partial class Establecimiento
{
    public int IdEstablecimiento { get; set; }

    public string? Ruc { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? RazonSocial { get; set; }

    public string? RepresentanteLegal { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
