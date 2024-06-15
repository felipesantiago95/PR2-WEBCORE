using PR2_WEBCORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Contrato
{
    public interface IEstablecimientoService
    {
        Task<List<Establecimiento>> GetAllEstablecimientos();
        Task<Establecimiento> GetEstablecimientoById(int id);
        Task<Establecimiento> CreateEstablecimiento(Establecimiento establecimiento);
        Task<Establecimiento> UpdateEstablecimiento(Establecimiento establecimiento);
        Task<bool> DeleteEstablecimiento(int id);
        Task<bool> EstablecimientoExists(int id);
    }
}
