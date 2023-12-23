using System.ComponentModel.DataAnnotations;

namespace BloggingSystem.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20), MinLength(6)]
        public string? Password { get; set; }

        [Required]
        [MinLength(4)]
        public string? Username { get; set; }
    }
}