using MockInterview.Domain.Models.EmployeeDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.CategoryDTO
{
    public class CategoryForCreationDTO : CategoryDTO
    {
        [Required]
        public Guid CategoryId { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<EmployeeForGetDTO> Specialist { get; set; }
    }
}
