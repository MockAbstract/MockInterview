using MockInterview.Domain.Models;
using MockInterview.Domain.Models.ClientDTO;

namespace MockInterview.Business.Interface
{
    public interface IClientServiceAsync : IGenericServiceAsync<ClientDTO>
    {
        Task<HttpResponse<string>> LoginAsync(LoginModel model);
    }
}
