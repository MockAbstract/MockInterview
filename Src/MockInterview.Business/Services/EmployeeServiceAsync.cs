using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.EmployeeDTO;

namespace MockInterview.Business.Services
{
    internal class EmployeeServiceAsync : IEmployeeServiceAsync
    {
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
    }
}
