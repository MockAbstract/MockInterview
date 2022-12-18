using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.AuthOption;
using MockInterview.Domain.Models.EmployeeDTO;
using MockInterview.Infrastructure.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MockInterview.Business.Services
{
    internal class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;
        private readonly IMapper mapper;
        private HttpResponse<EmployeeDTO> response;
        private readonly IFileServiceAsync fileServiceAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync employeeRepositoryAsync,
            IMapper mapper,
            IFileServiceAsync fileServiceAsync
            )
        {
            this.employeeRepositoryAsync = employeeRepositoryAsync;
            this.mapper = mapper;
            this.response = new HttpResponse<EmployeeDTO>();
            this.fileServiceAsync = fileServiceAsync;
        }
        public async Task<HttpResponse<EmployeeDTO>> SetImage(Guid employeeId, IFormFile file)
        {
            var employee = await employeeRepositoryAsync.FindAsync(e => e.Id == employeeId);
            if (employee != null)
            {
                employee.ImagePath = await fileServiceAsync.UploadFileAsync(file);

                bool isSucces = await employeeRepositoryAsync.UpdateAsync(employee);

                if (isSucces)
                    return response;

            }
            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }
        public async Task<HttpResponse<EmployeeDTO>> CreateAsync(EmployeeDTO model, Guid currentId)
        {
            var employee = await this.employeeRepositoryAsync
                .FindAsync(m => m.Login == model.Login);

            if (employee == null)
            {
                employee = mapper.Map<Employee>(model);
                employee.CreatedDate = DateTimeOffset.UtcNow;
                employee.CreatedBy = currentId;
                bool isSucces = await this.employeeRepositoryAsync
                    .InsertAsync(employee);

                if (isSucces)
                    return response;
            }

            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> DeleteAsync(Guid Id, Guid currentId)
        {
            bool isSucces = await employeeRepositoryAsync.RemoveAsync(Id, currentId);
            response.IsSuccess = isSucces;

            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> GetAllAsync()
        {
            var employes =  await employeeRepositoryAsync.GetAllAsync();

            response.TotalCount = employes.count;
            response.Result = mapper.Map<IEnumerable<EmployeeDTO>>(employes.entities);

            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> GetByIdAsync(Guid id)
        {
            var employe = await employeeRepositoryAsync.FindAsync(employe => employe.Id.Equals(id));
            response.Result = mapper.Map<IEnumerable<EmployeeForGetDTO>>(new List<Employee> { employe});

            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var employes = await employeeRepositoryAsync.GetPageListAsync(pageNumber, pageSize);
            response.TotalCount = employes.count;
            response.Result = mapper.Map<IEnumerable<EmployeeForGetDTO>>(employes.entities);

            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> UpdateAsync(EmployeeDTO model, Guid currentId)
        {
            var ExistUser = await employeeRepositoryAsync
                .FindAsync(u => u.Login == model.Login);

            if (ExistUser == null || ExistUser.Id == model.Id)
            {
                var employee = mapper.Map<Employee>(model);
                employee.LastModifiedDate= DateTime.UtcNow;
                employee.UpdatedBy = currentId;
                await employeeRepositoryAsync.UpdateAsync(employee);
            }
            else
            {
                response.IsSuccess = false;
                response.StatusMessage = "Username is already exist";
                response.StatusCode = StatusCodes.Status400BadRequest;
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
                new Claim(ClaimTypes.Role, employee.Role.ToString())
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
