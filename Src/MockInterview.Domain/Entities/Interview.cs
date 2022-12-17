using MockInterview.Domain.Enums;

namespace MockInterview.Domain.Entities
{
    public class Interview : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid EployeId { get; set; }
        public Employee Employee { get; set; }
        public DateTimeOffset InterviewDate { get; set; }
        public Level Level { get; set; }
        public decimal Price { get; set; }
        public decimal PaymentStatus { get; set; }
    }
}
