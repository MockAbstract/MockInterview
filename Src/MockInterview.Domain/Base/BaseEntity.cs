using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsActive { get; set; } = true;

        public void Remove() => IsActive= false;
    }
}
