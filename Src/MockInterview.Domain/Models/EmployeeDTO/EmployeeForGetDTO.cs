using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.EmployeeDTO
{
    public class EmployeeForGetDTO : EmployeeDTO
    {
        [JsonIgnore]
        public override string Login { get; set; }
        [JsonIgnore]
        public override string Password { get; set; }
        [JsonIgnore]
        public override string ConfirmPassword { get; set; }
        [JsonIgnore]
        public override IFormFile Image { get; set; }
    }
}
