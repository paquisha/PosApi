using AutoMapper;
using POS.Application.Dtos.Persona.Request;
using POS.Application.Dtos.Persona.Response;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Base.Response;
using POS.Utilities.Static;

namespace POS.Application.Mappers
{
    public class PersonaMappingsProfile : Profile
    {
        public PersonaMappingsProfile()
        {
            CreateMap<Persona, PersonaResponseDto>().ForMember(x => x.PersonaId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Status, x => x.MapFrom(y =>
                y.Status.Equals((int)StateTypes.Active) ? ReplyMessage.MESSAGE_ACTIVE : ReplyMessage.MESSAGE_INACTIVE)).ReverseMap();

            CreateMap<BaseEntityResponse<Persona>, BaseEntityResponse<PersonaResponseDto>>().ReverseMap();

            CreateMap<PersonaRequestDto, Persona>();
            CreateMap<Persona, PersonaSelectedResponseDto>()
                .ForMember(x => x.PersonaId, x => x.MapFrom(y => y.Id)).ReverseMap();
        }
    }
}
