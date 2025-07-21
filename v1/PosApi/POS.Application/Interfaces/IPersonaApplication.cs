using POS.Application.Commons.Base;
using POS.Application.Dtos.Persona.Request;
using POS.Application.Dtos.Persona.Response;
using POS.Infraestructure.Commons.Base.Request;
using POS.Infraestructure.Commons.Base.Response;

namespace POS.Application.Interfaces
{
    public interface IPersonaApplication
    {
        Task<BaseResponse<BaseEntityResponse<PersonaResponseDto>>> ListPersonasFiltered(BaseFilterRequest filter);
        Task<BaseResponse<IEnumerable<PersonaSelectedResponseDto>>> ListPersonas();
        Task<BaseResponse<PersonaResponseDto>> PersonaById(int personaId);
        Task<BaseResponse<bool>> RegisterPersona(PersonaRequestDto requestDto);
        Task<BaseResponse<bool>> EditPersona(int personaId, PersonaRequestDto requestDto);
        Task<BaseResponse<bool>> DeletePersona(int personaId);
    }
}