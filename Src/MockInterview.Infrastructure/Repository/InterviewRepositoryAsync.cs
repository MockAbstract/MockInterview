using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Infrastructure.Repository
{
    public class InterviewRepositoryAsync : GenericRepositoryAsync<Interview>, IInterviewRepositoryAsync
    {
        private readonly DbSet<Interview> interviews;

        public InterviewRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this.interviews = context.Interviews;
        }
    }
}
