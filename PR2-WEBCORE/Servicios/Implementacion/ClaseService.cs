// PR2_WEBCORE.Servicios.Implementacion.ClaseService.cs

using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Implementacion
{
    public class ClaseService : IClaseService
    {
        private readonly IngwebCoreContext _dbContext;

        public ClaseService(IngwebCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Clase>> GetAllAsync()
        {
            return await _dbContext.Clases.ToListAsync();
        }

        public async Task<Clase> GetByIdAsync(int id)
        {
            return await _dbContext.Clases.FindAsync(id);
        }

        public async Task<Clase> CreateAsync(Clase clase)
        {
            _dbContext.Clases.Add(clase);
            await _dbContext.SaveChangesAsync();
            return clase;
        }

        public async Task UpdateAsync(Clase clase)
        {
            _dbContext.Entry(clase).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clase = await _dbContext.Clases.FindAsync(id);
            if (clase != null)
            {
                _dbContext.Clases.Remove(clase);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
