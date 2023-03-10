using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.EmployeeDTO
{
    public class EmployeeForUpdateDTO : EmployeeDTO
    {
        [JsonIgnore]
        public override Guid CreatedBy { get; set; }

        [JsonIgnore]
        public override Guid UpdatedBy { get; set; }

        [JsonIgnore]
        public override DateTimeOffset CreatedDate { get; set; }

        [JsonIgnore]
        public override DateTimeOffset LastModifiedDate { get; set; }
    }
}
