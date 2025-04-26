namespace POS.Domain.Entities
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
