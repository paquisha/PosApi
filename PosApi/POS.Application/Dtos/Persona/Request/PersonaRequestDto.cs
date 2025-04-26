using System.ComponentModel.DataAnnotations;

namespace POS.Application.Dtos.Persona.Request
{
    public class PersonaRequestDto
    {
        public string? FirtsName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        public string? Image { get; set; }
    }
}
