using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;

namespace PR2_WEBCORE.Servicios.Implementacion
{
    public class RoleService : IRoleService
    {
        private readonly IngwebCoreContext _dbContext;

        public RoleService(IngwebCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task SaveRoleAsync(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _dbContext.Entry(role).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role != null)
            {
                _dbContext.Roles.Remove(role);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
