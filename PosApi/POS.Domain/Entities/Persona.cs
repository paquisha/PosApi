namespace POS.Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string? FirtsName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
    }
}
