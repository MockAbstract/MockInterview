using MockInterview.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Entities
{
    public class Employee :BaseEntity, BaseAudible
    {
         
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public TimeSpan Experience { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTimeOffset CreatedDate { get;set; }

        public DateTimeOffset LastModifiedDate { get; set; }

       
    }
}
