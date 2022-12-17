using AutoMapper;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.EmployeeDTO;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Business.Services
{
    internal class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepository;
        private readonly IMapper mapper;
        private HttpResponse<EmployeeDTO> response;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync employeeRepository, IMapper mapper, HttpResponse<EmployeeDTO> response)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
            this.response = response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> Create(EmployeeDTO model)
        {
            var employ = await employeeRepository.FindAsync(employe => employe.Login == model.Login);
            bool isSuccess = false  ;
            if (employ.Equals(null))
            {
                var employeEntity = mapper.Map<Employee>(model);
                isSuccess = await employeeRepository.InsertAsync(employeEntity);
                response.IsSuccess = isSuccess;
                return response;

            }

            response.IsSuccess = isSuccess;
            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> Delete(Guid Id)
        {
            bool isSucces = await employeeRepository.RemoveAsync(Id);
            response.IsSuccess = isSucces;
            return response;
        }

        public virtual async Task<HttpResponse<EmployeeDTO>> GetAll()
        {
            var employes =  await employeeRepository.GetAllAsync();

            response.TotalCount = employes.count;
            response.Result = mapper.Map<IEnumerable<EmployeeDTO>>(employes.entities);

            return response;
        }

        public async Task<HttpResponse<EmployeeDTO>> GetById(Guid id)
        {
            var employe = await employeeRepository.FindAsync(employe => employe.Id.Equals(id));
            response.Result = mapper.Map<IEnumerable<EmployeeDTO>>(new List<Employee> { employe});

            return response;
        }

        public Task<HttpResponse<EmployeeDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<EmployeeDTO>> Update(EmployeeDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
