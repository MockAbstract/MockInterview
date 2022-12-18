using MockInterview.Domain.Entities;
using System.Text.Json.Serialization;

namespace MockInterview.Domain.Models.InterviewDTO
{
    public class InterviewForModifiedDTO : InterviewDTO
    {
        [JsonIgnore]
        public override Client Client { get; set; }

        [JsonIgnore]
        public override Category Category { get; set; }

        [JsonIgnore]
        public override Employee Employee { get; set; }
    }
}
