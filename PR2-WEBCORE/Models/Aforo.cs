using System;
using System.Collections.Generic;

namespace PR2_WEBCORE.Models;

public partial class Aforo
{
    public int IdAforo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Porcentaje { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
