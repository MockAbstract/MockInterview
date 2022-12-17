using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models.EmployeeDTO;

namespace MockInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeeController(IEmployeeServiceAsync employeeServiceAsync)
        {
            this.employeeServiceAsync = employeeServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var response = await this.employeeServiceAsync
                .LoginAsync(model);

            return StatusCode(response.StatusCode, response);
        }
    }
}
