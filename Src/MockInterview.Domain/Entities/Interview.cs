using MockInterview.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Entities
{
    public class Interview : BaseEntity
    {
 
        [Required]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
       
        [Required]
        public Guid EployeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public DateTimeOffset InterviewDate { get; set; }
        
        [Required]
        public Level Level { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public decimal PaymentStatus { get; set; }

        [Required]
        public string LinkInterView { get; set; }
    }
}
