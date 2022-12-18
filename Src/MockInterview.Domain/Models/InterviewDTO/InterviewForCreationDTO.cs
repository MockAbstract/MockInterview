using MockInterview.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MockInterview.Domain.Models.InterviewDTO
{
    public class InterviewForCreationDTO : InterviewDTO
    {
        [JsonIgnore]

        public override Guid Id { get; set; }

        [JsonIgnore]
        public override Client Client { get; set; }

        [JsonIgnore]
        public override Category Category { get; set; }

        [JsonIgnore]
        public override Employee Employee { get; set; }

    }
}
