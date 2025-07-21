using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Entities
{
    [Table("tuser")]
    [Index(nameof(Email), IsUnique = true, Name = "uniqueUserEmail")]
    [Index(nameof(PassResetToken), IsUnique = true, Name = "uniquePassResetTokenCode")]
    [Index(nameof(VerificationToken), IsUnique = true, Name = "uniqueVerificationToken")]
    public class User : BaseEntity
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(75)]
        public string? Password { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public bool EmailVerified { get; set; } = false;

        [StringLength(200)]
        public string VerificationToken { get; set; }

        [StringLength(200)]
        public string? PassResetToken { get; set; }

        [Required]
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual ProfileSys? Profile { get; set; }
        public virtual Role? Role { get; set; }
        public virtual Medic? Medic { get; set; }
        public User()
        {
            Email = string.Empty;
            VerificationToken = string.Empty;
        }
    }
}
