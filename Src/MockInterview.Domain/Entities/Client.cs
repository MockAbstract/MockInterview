using MockInterview.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Entities
{
    public class Client : BaseEntity
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }

        public DateTimeOffset RegisterDate { get; set; } = DateTime.Now;

        public virtual DateTimeOffset ExperienceStartDate { get; set; }

        public virtual DateTimeOffset ExperienceEndDate { get; set; }

    }
}
