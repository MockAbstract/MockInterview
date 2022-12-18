using MockInterview.Domain.Models.EmployeeDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.CategoryDTO
{
    public class CategoryForUpdateDTO : CategoryDTO
    {
        [Required]
        public Guid SpecialistId { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<EmployeeForGetDTO> Specialist { get; set; }

    }
}
