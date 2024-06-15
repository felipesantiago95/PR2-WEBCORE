// PR2_WEBCORE.Servicios.Contrato.IClaseService.cs

using PR2_WEBCORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PR2_WEBCORE.Servicios.Contrato
{
    public interface IClaseService
    {
        Task<List<Clase>> GetAllAsync();
        Task<Clase> GetByIdAsync(int id);
        Task<Clase> CreateAsync(Clase clase);
        Task UpdateAsync(Clase clase);
        Task DeleteAsync(int id);
    }
}
