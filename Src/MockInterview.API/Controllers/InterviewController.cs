using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
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
        public virtual async Task<IActionResult> GetInterview()

    }
}
