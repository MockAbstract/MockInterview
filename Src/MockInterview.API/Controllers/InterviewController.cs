using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
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
        public async Task<IActionResult> CreateAsync([FromBody] InterviewForCreationDTO interview)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var userId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await interviewServiceAsync.CreateAsync(interview, userId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InterviewForModifiedDTO interview)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var userId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await interviewServiceAsync.UpdateAsync(interview, userId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var userId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await interviewServiceAsync.DeleteAsync(Id, userId);

            return StatusCode(response.StatusCode, response);
        }
    }
}
