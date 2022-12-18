using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.ClientDTO
{
    public class ClientForUpdateDTO : ClientDTO
    {
        [JsonIgnore]
        public override DateTimeOffset RegisterDate { get; set; }

    }
}
