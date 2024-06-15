using System;
using System.Collections.Generic;

namespace PR2_WEBCORE.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRols { get; } = new List<UsuarioRol>();
}
