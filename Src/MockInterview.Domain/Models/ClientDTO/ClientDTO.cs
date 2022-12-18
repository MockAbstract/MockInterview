using Microsoft.AspNetCore.Http;
using MockInterview.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.ClientDTO
{
    public class ClientDTO
    {
        public virtual Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public virtual string FirstName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public virtual string LastName { get; set; }

        [Required]
        public virtual Level Level { get; set; }

        [Required]
        [Phone]
        public virtual string PhoneNumber { get; set; }

        public virtual DateTimeOffset ExperienceStartDate { get; set; }

        public virtual DateTimeOffset ExperienceEndDate { get; set; }

        public virtual string ImagePath { get; set; }

        [JsonIgnore]
        public virtual DateTimeOffset RegisterDate { get; set; } = DateTime.Now;

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public virtual string Login { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public virtual string Password { get; set; }

        [Compare("Password")]
        public virtual string ConfirmPassword { get; set; }
        [JsonIgnore]
        public virtual IFormFile Image { get; set; }
    }
}
