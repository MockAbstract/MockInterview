using AutoMapper;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.InterviewDTO;

namespace MockInterview.Business.Services
{
    public class InterviewServiceAsync : IInterviewServiceAsync
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;
        private IMapper mapper;
        private readonly HttpResponse<InterviewDTO> response;

        public InterviewServiceAsync(IInterviewServiceAsync interviewServiceAsync, IMapper mapper)
        {
            this.interviewServiceAsync = interviewServiceAsync;
            this.mapper = mapper;
            this.response = new HttpResponse<InterviewDTO>();
        }

        public Task<HttpResponse<InterviewDTO>> CreateAsync(InterviewDTO model, Guid currentId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<InterviewDTO>> DeleteAsync(Guid Id, Guid currentId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<InterviewDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<InterviewDTO>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<InterviewDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<InterviewDTO>> UpdateAsync(InterviewDTO model, Guid currentId)
        {
            throw new NotImplementedException();
        }
    }
}
