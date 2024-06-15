using Microsoft.EntityFrameworkCore;
using PR2_WEBCORE.Models;
using PR2_WEBCORE.Servicios.Contrato;

namespace PR2_WEBCORE.Servicios.Implementacion
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IngwebCoreContext _dbContext;

        public CategoriaService(IngwebCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Categorium>> GetAllCategoriasAsync()
        {
            return await _dbContext.Categoria.ToListAsync();
        }

        public async Task<Categorium> GetCategoriaByIdAsync(int id)
        {
            return await _dbContext.Categoria.FindAsync(id);
        }

        public async Task SaveCategoriaAsync(Categorium categoria)
        {
            _dbContext.Categoria.Add(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoriaAsync(Categorium categoria)
        {
            _dbContext.Entry(categoria).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var categoria = await _dbContext.Categoria.FindAsync(id);
            if (categoria != null)
            {
                _dbContext.Categoria.Remove(categoria);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
