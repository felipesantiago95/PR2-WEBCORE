using PR2_WEBCORE.Models;

namespace PR2_WEBCORE.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<List<Categorium>> GetAllCategoriasAsync();
        Task<Categorium> GetCategoriaByIdAsync(int id);
        Task SaveCategoriaAsync(Categorium categoria);
        Task UpdateCategoriaAsync(Categorium categoria);
        Task DeleteCategoriaAsync(int id);
    }
}
