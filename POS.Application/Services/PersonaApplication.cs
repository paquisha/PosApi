using AutoMapper;
using POS.Application.Commons.Base;
using POS.Application.Dtos.Persona.Request;
using POS.Application.Dtos.Persona.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Persona;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Base.Request;
using POS.Infraestructure.Commons.Base.Response;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services
{
    public class PersonaApplication : IPersonaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PersonaValidator _validator;

        public PersonaApplication(IUnitOfWork unitOfWork, IMapper mapper, PersonaValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<BaseEntityResponse<PersonaResponseDto>>> ListPersonasFiltered(BaseFilterRequest filter)
        {
            try
            {
                var response = new BaseResponse<BaseEntityResponse<PersonaResponseDto>>();
                var parameter = await _unitOfWork.Persona.ListPersonasFiltered(filter);

                if (parameter is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<BaseEntityResponse<PersonaResponseDto>>(parameter);
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse<IEnumerable<PersonaSelectedResponseDto>>> ListPersonas()
        {
            try
            {
                var response = new BaseResponse<IEnumerable<PersonaSelectedResponseDto>>();
                var parameter = await _unitOfWork.Persona.GetAllAsync();

                if (parameter is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<PersonaSelectedResponseDto>>(parameter);
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse<PersonaResponseDto>> PersonaById(int personaId)
        {
            try
            {
                var response = new BaseResponse<PersonaResponseDto>();
                var parameter = await _unitOfWork.Persona.GetByIdAsync(personaId);

                if (parameter is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<PersonaResponseDto>(parameter);
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse<bool>> RegisterPersona(PersonaRequestDto requestDto)
        {
            try
            {
                var response = new BaseResponse<bool>();
                var validationResult = await _validator.ValidateAsync(requestDto);

                if (!validationResult.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                    return response;
                }

                var parameter = _mapper.Map<Persona>(requestDto);
                response.Data = await _unitOfWork.Persona.RegisterAsync(parameter);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse<bool>> EditPersona(int personaId, PersonaRequestDto requestDto)
        {
            try
            {
                var response = new BaseResponse<bool>();
                var parameterEdit = await PersonaById(personaId);

                if (parameterEdit.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                var parameter = _mapper.Map<Persona>(requestDto);
                parameter.Id = personaId;
                response.Data = await _unitOfWork.Persona.EditAsync(parameter);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_UPDATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BaseResponse<bool>> DeletePersona(int personaId)
        {
            try
            {
                var response = new BaseResponse<bool>();
                var parameter = await PersonaById(personaId);

                if (parameter.Data is null)
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }

                response.Data = await _unitOfWork.Persona.RemoveAsync(personaId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_DELETE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
