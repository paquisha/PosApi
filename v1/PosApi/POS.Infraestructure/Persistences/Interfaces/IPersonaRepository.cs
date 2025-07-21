using POS.Domain.Entities;
using POS.Infraestructure.Commons.Base.Request;
using POS.Infraestructure.Commons.Base.Response;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<BaseEntityResponse<Persona>> ListPersonasFiltered(BaseFilterRequest filters);
    }
}
