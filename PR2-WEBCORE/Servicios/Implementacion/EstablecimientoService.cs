using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Implementacion
{
    public class EstablecimientoService : IEstablecimientoService
    {
        private readonly IngwebCoreContext _context;

        public EstablecimientoService(IngwebCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Establecimiento>> GetAllEstablecimientos()
        {
            return await _context.Establecimientos.ToListAsync();
        }

        public async Task<Establecimiento> GetEstablecimientoById(int id)
        {
            return await _context.Establecimientos.FindAsync(id);
        }

        public async Task<Establecimiento> CreateEstablecimiento(Establecimiento establecimiento)
        {
            _context.Establecimientos.Add(establecimiento);
            await _context.SaveChangesAsync();
            return establecimiento;
        }

        public async Task<Establecimiento> UpdateEstablecimiento(Establecimiento establecimiento)
        {
            _context.Entry(establecimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return establecimiento;
        }

        public async Task<bool> DeleteEstablecimiento(int id)
        {
            var establecimiento = await _context.Establecimientos.FindAsync(id);
            if (establecimiento == null)
            {
                return false;
            }

            _context.Establecimientos.Remove(establecimiento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EstablecimientoExists(int id)
        {
            return await _context.Establecimientos.AnyAsync(e => e.IdEstablecimiento == id);
        }
    }
}
