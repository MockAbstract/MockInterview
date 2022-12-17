using AutoMapper;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.AuthOption;
using MockInterview.Domain.Models.EmployeeDTO;
using MockInterview.Infrastructure.Interface;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MockInterview.Business.Services
{
    internal class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;
        private readonly IMapper mapper;
        private HttpResponse<Employee> response;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync employeeRepositoryAsync, IMapper mapper)
        {
            this.employeeRepositoryAsync = employeeRepositoryAsync;
            this.mapper = mapper;
            response = new HttpResponse<Employee>();
        }
        public Task<HttpResponse<EmployeeDTO>> Create(EmployeeDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<EmployeeDTO>> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<EmployeeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<EmployeeDTO>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<EmployeeDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

       

        public Task<HttpResponse<EmployeeDTO>> Update(EmployeeDTO model)
        {
            throw new NotImplementedException();
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
            var employee = await this.employeeRepositoryAsync.LoginAsync(login.Login, login.Password);
            if (employee is not null)
            {
                var claims = GenerateClaims(employee);
                string token = GetToken(claims);
                Response.Result = new List<string> { token };
                return Response;
            }
            Response.StatusCode = 404;
            Response.IsSuccess = false;
            return Response;
        }
        private List<Claim> GenerateClaims(Employee employee)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Role, employee.Role.ToString()),
                new Claim("Permissions", JsonConvert.SerializeObject(employee.Permission))
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
