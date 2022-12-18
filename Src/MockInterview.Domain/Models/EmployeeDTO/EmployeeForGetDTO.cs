using MockInterview.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterview.Domain.Models.EmployeeDTO
{
    public class EmployeeForGetDTO
    {
        [Required]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual Level Level { get; set; }

        [Required]
        public virtual string PhoneNumber { get; set; }

        public virtual string ImagePath { get; set; }
        public virtual DateTimeOffset ExperienceStartDate { get; set; }
        public virtual DateTimeOffset ExperienceEndDate { get; set; }
    }
}
