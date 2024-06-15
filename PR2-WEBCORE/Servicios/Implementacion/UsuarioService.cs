using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IngwebCoreContext dbContext;

        public UsuarioService(IngwebCoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
            return await dbContext.Usuarios
                .Include(u => u.UsuarioRols)
                .ThenInclude(ur => ur.IdRolesNavigation)
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);
        }

        public async Task<Usuario> SaveUsuarios(Usuario usuario)
        {
            dbContext.Usuarios.Add(usuario);
            await dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Role> GetRole(int id)
        {
            return await dbContext.Roles.FindAsync(id);
        }

        public async Task<ICollection<Role>> GetRolesByUserId(int userId)
        {
            return await dbContext.UsuarioRols
                .Where(ur => ur.IdUsuario == userId)
                .Select(ur => ur.IdRolesNavigation)
                .ToListAsync();
        }
    }
}
