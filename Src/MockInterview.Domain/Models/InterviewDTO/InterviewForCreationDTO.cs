using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MockInterview.Domain.Models.InterviewDTO
{
    public class InterviewForCreationDTO : InterviewDTO
    {
        [JsonIgnore]
        public Guid ClientId { get; set; }

    }
}
