using MockInterview.Domain.Models.EmployeeDTO;
using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Models.CategoryDTO
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public virtual IEnumerable<EmployeeForGetDTO> Specialist { get; set; }
    }
}
