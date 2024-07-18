using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Dtos.Persona.Request;
using POS.Application.Interfaces;
using POS.Infraestructure.Commons.Base.Request;

namespace POS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaApplication _persona;

        public PersonaController(IPersonaApplication persona)
        {
            _persona = persona;
        }

        [HttpPost("Filtered")]
        public async Task<IActionResult> PersonFiltered([FromBody] BaseFilterRequest filter)
        {
            try
            {
                var response = await _persona.ListPersonasFiltered(filter);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet("select")]
        public async Task<IActionResult> ListPersona()
        {
            try
            {
                var response = await _persona.ListPersonas();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{personaId:int}")]
        public async Task<IActionResult> GetPorsonaById(int personaId)
        {
            try
            {
                var response = await _persona.PersonaById(personaId);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPersona([FromBody] PersonaRequestDto requestDto)
        {
            try
            {
                var response = await _persona.RegisterPersona(requestDto);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit/{personaId}")]
        public async Task<IActionResult> EditPersona(int personaId, [FromBody] PersonaRequestDto requestDto)
        {
            try
            {
                var response = await _persona.EditPersona(personaId, requestDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove/{personaId}")]
        public async Task<IActionResult> RemovePurpose(int personaId)
        {
            try
            {
                var response = await _persona.DeletePersona(personaId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
