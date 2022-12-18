using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.AuthOption;
using MockInterview.Domain.Models.ClientDTO;
using MockInterview.Infrastructure.Interface;
using MockInterview.Infrastructure.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MockInterview.Business.Services
{
    public class ClientServiceAsync : IClientServiceAsync
    {
        private readonly IClientRepositoryAsync clientRepositoryAsync;
        private readonly IMapper mapper;
        private HttpResponse<ClientDTO> response;
        private readonly IFileServiceAsync fileServiceAsync;

        public ClientServiceAsync(IClientRepositoryAsync clientRepositoryAsync,
            IMapper mapper,
            IFileServiceAsync fileServiceAsync)
        {
            this.fileServiceAsync = fileServiceAsync;
            this.clientRepositoryAsync = clientRepositoryAsync;
            this.mapper = mapper;
            this.response = new HttpResponse<ClientDTO>();
        }
        public async Task<HttpResponse<ClientDTO>> CreateAsync(ClientDTO model, Guid currentId)
        {
            var client = await this.clientRepositoryAsync
                 .FindAsync(m => m.Login == model.Login);

            if (client == null)
            {
                client = mapper.Map<Client>(model);
                client.RegisterDate = DateTimeOffset.UtcNow;
                client.ImagePath = await fileServiceAsync.UploadFileAsync(model.Image);
                bool isSucces = await this.clientRepositoryAsync
                    .InsertAsync(client);

                if (isSucces)
                    return response;
            }

            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> SetImage(Guid clientId, IFormFile file)
        {
            var employee = await clientRepositoryAsync.FindAsync(e => e.Id == clientId);
            if (employee != null)
            {
                employee.ImagePath = await fileServiceAsync.UploadFileAsync(file);

                bool isSucces = await clientRepositoryAsync.UpdateAsync(employee);

                if (isSucces)
                    return response;

            }
            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> DeleteAsync(Guid Id, Guid currentId)
        {
            if(currentId != Id)
            {
                response.IsSuccess = false;
                response.StatusMessage = "Access Denied";
                response.StatusCode = Microsoft.AspNetCore.Http
                    .StatusCodes.Status403Forbidden;

                return response;
            }
            bool isSucces = await clientRepositoryAsync.RemoveAsync(Id);
            response.IsSuccess = isSucces;

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> GetAllAsync()
        {
            var clients = await clientRepositoryAsync.GetAllAsync();

            response.TotalCount = clients.count;
            response.Result = mapper.Map<IEnumerable<ClientForGetDTO>>(clients.entities);

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> GetByIdAsync(Guid id)
        {
            var client = await clientRepositoryAsync.FindAsync(employe => employe.Id.Equals(id));
            response.Result = mapper.Map<IEnumerable<ClientForGetDTO>>(new List<Client> { client });

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var clients = await clientRepositoryAsync.GetPageListAsync(pageNumber, pageSize);

            response.TotalCount = clients.count;
            response.Result = mapper.Map<IEnumerable<ClientForGetDTO>>(clients.entities);

            return response;
        }
        
        public async Task<HttpResponse<ClientDTO>> UpdateAsync(ClientDTO model, Guid currentId)
        {
            if(model.Id != currentId)
            {
                response.IsSuccess = false;
                response.StatusMessage = "Access Denied";
                response.StatusCode = Microsoft.AspNetCore.Http
                    .StatusCodes.Status403Forbidden;

                return response;
            }
            var ExistUser = await clientRepositoryAsync
                .FindAsync(u => u.Login == model.Login);

            if (ExistUser == null || ExistUser.Id == model.Id)
            {
                var user = mapper.Map<Client>(model);

                await clientRepositoryAsync.UpdateAsync(user);
            }
            else
            {
                response.IsSuccess = false;
                response.StatusMessage = "Username is already exist";
                response.StatusCode = Microsoft.AspNetCore.Http
                    .StatusCodes.Status400BadRequest;
            }

            return response;
        }

        #region LoginMethod
        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<HttpResponse<string>> LoginAsync(LoginModel login)
        {
            HttpResponse<string> Response = new();
            var client = await this.clientRepositoryAsync.LoginAsync(login.Login, login.Password);
            if (client is not null)
            {
                var claims = GenerateClaims(client);
                string token = GetToken(claims);
                Response.Result = new List<string> { token };
                return Response;
            }
            Response.StatusCode = 404;
            Response.IsSuccess = false;
            return Response;
        }
        private List<Claim> GenerateClaims(Client client)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
            };
        }
        private string GetToken(List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        #endregion

    }
}
