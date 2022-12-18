using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.ClientDTO;
using System.Security.Claims;

namespace MockInterview.API.Controllers
{
    [Route("account-management/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IClientServiceAsync clientServiceAsync;

        public AccountsController(IClientServiceAsync clientServiceAsync,
            IEmployeeServiceAsync employeeServiceAsync)
        {
            this.employeeServiceAsync = employeeServiceAsync;
            this.clientServiceAsync = clientServiceAsync;
        }

        [HttpPost("client/login")]
        public async Task<IActionResult> ClientLoginAsync([FromBody] LoginModel model)
        {
            var response = await this.clientServiceAsync
                .LoginAsync(model);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("employee/login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel model)
        {
            var response = await this.employeeServiceAsync
                .LoginAsync(model);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("client/register")]
        public async Task<IActionResult> RegisterClientAsync(ClientForCreationDTO client)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var clientId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await clientServiceAsync
                .CreateAsync(client, clientId);

            return StatusCode(response.StatusCode, response);
        }
    }
}
