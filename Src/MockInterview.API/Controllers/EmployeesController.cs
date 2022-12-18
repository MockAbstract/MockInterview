using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.EmployeeDTO;
using System.Security.Claims;

namespace MockInterview.API.Controllers
{
    [Route("api/[controller]")]
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
            var response = await employeeServiceAsync.GetAll();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployeeById([FromQuery]Guid id)
        {
            var response = await employeeServiceAsync.GetById(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetEmployeePageAsync([FromQuery]int pageNumber, int pageSize)
        {
            var response = await employeeServiceAsync
                .GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(EmployeeForCreationDTO employee)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value); 

            var response = await employeeServiceAsync.CreateAsync(employee,employeeId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(EmployeeForUpdateDTO employee)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await employeeServiceAsync.UpdateAsync(employee,employeeId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await employeeServiceAsync.DeleteAsync(id,employeeId);

            return StatusCode(response.StatusCode, response);
        }
    }
}
