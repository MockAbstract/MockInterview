using Microsoft.AspNetCore.Http;
using MockInterview.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.EmployeeDTO
{
    public class EmployeeDTO
    {
        [Required]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual Level Level { get; set; }

        [Required]
        public virtual string PhoneNumber { get; set; }

        public virtual string ImagePath { get; set; }

        public virtual DateTimeOffset ExperienceStartDate { get; set; }

        public virtual DateTimeOffset ExperienceEndDate { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [Required]
        public virtual string Login { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public virtual string Password { get; set; }

        [Compare("Password")]
        public virtual string ConfirmPassword { get; set; }

        [JsonIgnore]
        public virtual IFormFile Image { get; set; }

        public virtual Guid CreatedBy { get; set; }

        public virtual Guid UpdatedBy { get; set; }

        public virtual DateTimeOffset CreatedDate { get; set; }

        public virtual DateTimeOffset LastModifiedDate { get; set; }


    }
}
