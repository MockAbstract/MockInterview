using MockInterview.Domain.Entities;
using MockInterview.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Models.InterviewDTO
{
    public class InterviewDTO
    {
        public virtual Guid Id { get; set; }
        [Required]
        public virtual Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        [Required]
        public virtual Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public virtual Guid EployeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public virtual DateTimeOffset InterviewDate { get; set; }

        [Required]
        public virtual Level Level { get; set; }

        [Required]
        public virtual decimal Price { get; set; }

        [Required]
        public virtual decimal PaymentStatus { get; set; }

        [Required]
        public virtual string LinkInterview { get; set; }
    }
}
