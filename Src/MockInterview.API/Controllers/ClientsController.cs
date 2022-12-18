using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models.EmployeeDTO;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.ClientDTO;
using System.Security.Claims;

namespace MockInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientServiceAsync clientServiceAsync;

        public ClientsController(IClientServiceAsync clientServiceAsync)
        {
            this.clientServiceAsync = clientServiceAsync;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> GetClients()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;

            var response = await clientServiceAsync.GetAll();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> GetClientById([FromQuery] Guid id)
        {
            var response = await clientServiceAsync.GetById(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("page")]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> GetClientPageAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await clientServiceAsync
                .GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);

        }

        [HttpPut]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> UpdateAsync(ClientForUpdateDTO client)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var clientId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await clientServiceAsync.UpdateAsync(client,clientId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("id")]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var clientId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await clientServiceAsync.DeleteAsync(id, clientId);

            return StatusCode(response.StatusCode, response);
        }
    }
}
