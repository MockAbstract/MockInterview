using System.ComponentModel.DataAnnotations;

namespace MockInterview.Domain.Models.EmployeeDTO
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
