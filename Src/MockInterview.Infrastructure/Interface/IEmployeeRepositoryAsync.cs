using MockInterview.Domain.Entities;

namespace MockInterview.Infrastructure.Interface
{
    public interface IEmployeeRepositoryAsync : IGenericRepositoryAsync<Employee>
    {
        public Task<Employee> LoginAsync(string login, string password);
        Task<bool> RemoveAsync(Guid id, Guid currentId);
    }
}
