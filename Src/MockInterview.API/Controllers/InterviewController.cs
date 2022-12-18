using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.InterviewDTO;

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



    }
}
