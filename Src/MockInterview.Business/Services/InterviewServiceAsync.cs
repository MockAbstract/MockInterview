using AutoMapper;
using Microsoft.AspNetCore.Http;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.InterviewDTO;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Business.Services
{
    public class InterviewServiceAsync : IInterviewServiceAsync
    {
        private readonly IInterviewRepositoryAsync interviewRepositoryAsync;
        private IMapper mapper;
        private readonly HttpResponse<InterviewDTO> response;

        public InterviewServiceAsync(IInterviewRepositoryAsync interviewRepositoryAsync, IMapper mapper)
        {
            this.interviewRepositoryAsync = interviewRepositoryAsync;
            this.mapper = mapper;
            this.response = new HttpResponse<InterviewDTO>();
        }

        public async Task<HttpResponse<InterviewDTO>> CreateAsync(InterviewDTO model, Guid currentId)
        {
            var interview = mapper.Map<Interview>(model);
            var isSucces = await interviewRepositoryAsync.InsertAsync(interview);
            if (isSucces)
                return response;

            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
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
