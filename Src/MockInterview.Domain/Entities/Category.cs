using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public virtual ICollection<Employee> Specialist { get; set; }
    }
}
