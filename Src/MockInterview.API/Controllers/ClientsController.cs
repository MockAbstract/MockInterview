using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.ClientDTO;
using MockInterview.Domain.Models.EmployeeDTO;
using System.Security.Claims;

namespace MockInterview.API.Controllers
{
    [Route("client-management/clients")]
    [ApiController]
    [Authorize]
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
            var response = await clientServiceAsync.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("image")]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> UpdateImageAsync(Guid clientId, IFormFile file)
        {
            string imageExtension = Path.GetExtension(file.FileName);

            if (imageExtension == ".png" || imageExtension == ".jpg")
            {
                var response = await clientServiceAsync.SetImage(clientId, file);

                return StatusCode(response.StatusCode, response);
            }
            return BadRequest("File type must be image");
        }


        [HttpGet("id")]
        [ProducesResponseType(typeof(HttpResponse<ClientDTO>), 200)]
        public async Task<IActionResult> GetClientById([FromQuery] Guid id)
        {
            var response = await clientServiceAsync.GetByIdAsync(id);

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
