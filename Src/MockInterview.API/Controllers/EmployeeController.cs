using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
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

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse<EmployeeDTO>),200)]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var response = await employeeServiceAsync.GetAll();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var response = await employeeServiceAsync.GetById(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            var response = await this.employeeServiceAsync
                .LoginAsync(model);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeForCreationDTO employee)
        {
            var response = await employeeServiceAsync.CreateAsync(employee);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EmployeeForUpdateDTO employee)
        {
            var response = await employeeServiceAsync.UpdateAsync(employee);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await employeeServiceAsync.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
