using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Infrastructure.Repository
{
    public class ClientRepositoryAsync : GenericRepositoryAsync<Client>, IClientRepositoryAsync
    {
        private readonly DbSet<Client> client;

        public ClientRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this.client = context.Clients;
        }

        public async Task<Client> LoginAsync(string login, string password) =>
              await FindAsync(e => e.Login == login && e.Password == password);
    }
}
