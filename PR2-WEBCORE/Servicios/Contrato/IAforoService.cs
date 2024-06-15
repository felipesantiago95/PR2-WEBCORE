using PR2_WEBCORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Contrato
{
    public interface IAforoService
    {
        Task<List<Aforo>> GetAllAforos();
        Task<Aforo> GetAforoById(int id);
        Task<Aforo> CreateAforo(Aforo aforo);
        Task<Aforo> UpdateAforo(Aforo aforo);
        Task<bool> DeleteAforo(int id);
        Task<bool> AforoExists(int id);
    }
}
