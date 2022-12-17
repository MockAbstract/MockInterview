using MockInterview.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Entities
{
    public class Client : BaseEntity
    {
        public Guid Id { get; set; }

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

        public DateTime RegisterDate { get; set; } = DateTime.Now;

    }
}
