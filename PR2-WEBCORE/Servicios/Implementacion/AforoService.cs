using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Implementacion
{
    public class AforoService : IAforoService
    {
        private readonly IngwebCoreContext _context;

        public AforoService(IngwebCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Aforo>> GetAllAforos()
        {
            return await _context.Aforos.ToListAsync();
        }

        public async Task<Aforo> GetAforoById(int id)
        {
            return await _context.Aforos.FindAsync(id);
        }

        public async Task<Aforo> CreateAforo(Aforo aforo)
        {
            _context.Aforos.Add(aforo);
            await _context.SaveChangesAsync();
            return aforo;
        }

        public async Task<Aforo> UpdateAforo(Aforo aforo)
        {
            _context.Entry(aforo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return aforo;
        }

        public async Task<bool> DeleteAforo(int id)
        {
            var aforo = await _context.Aforos.FindAsync(id);
            if (aforo == null)
            {
                return false;
            }

            _context.Aforos.Remove(aforo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AforoExists(int id)
        {
            return await _context.Aforos.AnyAsync(e => e.IdAforo == id);
        }
    }
}
