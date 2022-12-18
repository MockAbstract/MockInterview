using MockInterview.Domain.Models;
using MockInterview.Domain.Models.ClientDTO;
using MockInterview.Domain.Models.EmployeeDTO;

namespace MockInterview.Business.Interface
{
    public interface IClientServiceAsync : IGenericServiceAsync<ClientDTO>
    {
        Task<HttpResponse<string>> LoginAsync(LoginModel model);
    }
}
