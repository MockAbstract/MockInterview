using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain
{
    public interface BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
