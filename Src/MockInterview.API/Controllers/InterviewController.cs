using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.InterviewDTO;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Principal;

namespace MockInterview.API.Controllers
{
    [Route("interview-management/interviews")]
    [ApiController]
    [Authorize]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;

        public InterviewController(IInterviewServiceAsync interviewServiceAsync)
        {
            this.interviewServiceAsync = interviewServiceAsync;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Expert")]
        public async Task<IActionResult> CreateAsync([FromBody] InterviewForCreationDTO interview)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var userId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await interviewServiceAsync.CreateAsync(interview, userId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Expert")]
        public async Task<IActionResult> UpdateAsync([FromBody] InterviewForModifiedDTO interview)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var userId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await interviewServiceAsync.UpdateAsync(interview, userId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin, Expert")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var userId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);
        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse<InterviewDTO>), 200)]
        public async Task<IActionResult> GetInterviews()
        {
            var response = await interviewServiceAsync.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(HttpResponse<InterviewDTO>), 200)]
        public async Task<IActionResult> GetClientById([FromQuery] Guid id)
        {
            var response = await interviewServiceAsync.GetByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("page")]
        [ProducesResponseType(typeof(HttpResponse<InterviewDTO>), 200)]
        public async Task<IActionResult> GetClientPageAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await interviewServiceAsync
                .GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);

        }


            var response = await interviewServiceAsync.DeleteAsync(Id, userId);

            return StatusCode(response.StatusCode, response);
        }
    }
}
