using System;
using System.Collections.Generic;

namespace PR2_WEBCORE.Models;

public partial class UsuarioRol
{
    public int IdUserRoles { get; set; }

    public int IdUsuario { get; set; }

    public int IdRoles { get; set; }

    public virtual Role IdRolesNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
