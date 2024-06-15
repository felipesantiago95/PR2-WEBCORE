using System;
using System.Collections.Generic;

namespace PR2_WEBCORE.Models;

public partial class Clase
{
    public int IdClase { get; set; }

    public String? Descripcion { get; set; }

    public decimal? Porcentaje { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
