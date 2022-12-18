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

        public async Task<HttpResponse<InterviewDTO>> DeleteAsync(Guid Id, Guid currentId)
        {
            if(Id != Guid.Empty)
            {
                var isSucces = await interviewRepositoryAsync.RemoveAsync(Id);

                if (isSucces)
                    return response;
            
            }
            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }

        public virtual async Task<HttpResponse<InterviewDTO>> GetAllAsync()
        {
            var interviews = await interviewRepositoryAsync.GetAllAsync();

            response.TotalCount = interviews.count;
            response.Result = mapper.Map<IEnumerable<InterviewDTO>>(interviews.entities);

            return response;
        }

        public virtual async Task<HttpResponse<InterviewDTO>> GetByIdAsync(Guid id)
        {
            var interview = await interviewRepositoryAsync.FindAsync(interview => interview.Id.Equals(id));
            response.Result = mapper.Map<IEnumerable<InterviewForGetDTO>>(new List<Interview> { interview });

            return response;
        }

        public Task<HttpResponse<InterviewDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponse<InterviewDTO>> UpdateAsync(InterviewDTO model, Guid currentId)
        {
            var interview = mapper.Map<Interview>(model);
            var isSucces = await interviewRepositoryAsync.UpdateAsync(interview);

            if (isSucces)
                return response;

            response.IsSuccess = false;
            response.StatusCode = StatusCodes.Status400BadRequest;

            return response;
        }
    }
}
