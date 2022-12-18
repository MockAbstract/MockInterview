using MockInterview.Domain.Models.EmployeeDTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.CategoryDTO
{
    public class CategoryForCreationDTO : CategoryDTO
    {
        [JsonIgnore]
        public override Guid Id { get; set; }

        [JsonIgnore]
        public override IEnumerable<EmployeeForGetDTO> Specialist { get; set; }
    }
}
