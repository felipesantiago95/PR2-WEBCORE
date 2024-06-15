using PR2_WEBCORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);
        Task<Usuario> SaveUsuarios(Usuario usuario);
        Task<Role> GetRole(int id);
        Task<ICollection<Role>> GetRolesByUserId(int userId);
    }
}
