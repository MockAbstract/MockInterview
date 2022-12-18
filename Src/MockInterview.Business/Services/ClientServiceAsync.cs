﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.AuthOption;
using MockInterview.Domain.Models.ClientDTO;
using MockInterview.Domain.Models.EmployeeDTO;
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

        public ClientServiceAsync(IClientRepositoryAsync clientRepositoryAsync, IMapper mapper)
        {
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
                bool isSucces = await this.clientRepositoryAsync
                    .InsertAsync(client);

                if (isSucces)
                    return response;
            }

            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> DeleteAsync(Guid Id, Guid currentId)
        {
            bool isSucces = await clientRepositoryAsync.RemoveAsync(Id);
            response.IsSuccess = isSucces;

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> GetAll()
        {
            var clients = await clientRepositoryAsync.GetAllAsync();

            response.TotalCount = clients.count;
            response.Result = mapper.Map<IEnumerable<ClientDTO>>(clients.entities);

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> GetById(Guid id)
        {
            var client = await clientRepositoryAsync.FindAsync(employe => employe.Id.Equals(id));
            response.Result = mapper.Map<IEnumerable<ClientDTO>>(new List<Client> { client });

            return response;
        }

        public async Task<HttpResponse<ClientDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var clients = await clientRepositoryAsync.GetPageListAsync(pageNumber, pageSize);

            response.TotalCount = clients.count;
            response.Result = mapper.Map<IEnumerable<ClientDTO>>(clients.entities);

            return response;
        }
        
        public async Task<HttpResponse<ClientDTO>> UpdateAsync(ClientDTO model, Guid currentId)
        {
            HttpResponse<ClientDTO> response = new();
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
                expires: DateTime.UtcNow.AddHours(1)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        #endregion

    }
}
