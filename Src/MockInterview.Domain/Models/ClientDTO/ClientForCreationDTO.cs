using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.ClientDTO
{
    public class ClientForCreationDTO : ClientDTO
    {
        [JsonIgnore]
        public override Guid Id { get; set; }

        [JsonIgnore]
        public override DateTimeOffset RegisterDate { get; set; }

        [JsonIgnore]
        public override string ImagePath { get; set; }
    }
}
