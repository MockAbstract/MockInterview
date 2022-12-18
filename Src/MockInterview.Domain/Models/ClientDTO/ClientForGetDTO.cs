using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.ClientDTO
{
    public class ClientForGetDTO : ClientDTO
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
