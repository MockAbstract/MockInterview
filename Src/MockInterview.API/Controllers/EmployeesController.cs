using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.EmployeeDTO;
using System.Net.Mime;
using System.Security.Claims;

namespace MockInterview.API.Controllers
{
    [Route("employee-management/employees")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public EmployeesController(IEmployeeServiceAsync employeeServiceAsync)
        {
            this.employeeServiceAsync = employeeServiceAsync;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse<EmployeeDTO>), 200)]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var response = await employeeServiceAsync.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] Guid id)
        {
            var response = await employeeServiceAsync.GetByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetEmployeePageAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await employeeServiceAsync
                .GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeForCreationDTO employee)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await employeeServiceAsync.CreateAsync(employee, employeeId);

            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("image")]
        public async Task<IActionResult> UpdateImageAsync([FromForm] Guid employeeId, IFormFile file)
        {
            string imageExtension = Path.GetExtension(file.FileName);

            if (imageExtension == ".png" || imageExtension == ".jpg")
            {
                var response = await employeeServiceAsync.SetImage(employeeId, file);

                return StatusCode(response.StatusCode, response);
            }
            return BadRequest("File type must be image");

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(EmployeeForUpdateDTO employee)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await employeeServiceAsync.UpdateAsync(employee, employeeId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await employeeServiceAsync.DeleteAsync(id, employeeId);

            return StatusCode(response.StatusCode, response);
        }
    }
}
