using System;
using System.Collections.Generic;

namespace PR2_WEBCORE.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; } = new List<UsuarioRol>();
}
