using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CureX.Domain.Models
{
    public class Patient
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        [Phone]
        public string Contact { get; set; } = string.Empty;
        [Required]
        [StringLength(10, MinimumLength = 1)]

        public string Gender { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Address { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
    }

}