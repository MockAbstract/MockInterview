using MockInterview.Domain.Entities;

namespace MockInterview.Infrastructure.Interface
{
    public interface IClientRepositoryAsync : IGenericRepositoryAsync<Client>
    {
        Task<Client> LoginAsync(string login, string password);
    }
}
