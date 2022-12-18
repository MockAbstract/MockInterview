using AutoMapper;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.CategoryDTO;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Business.Services
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        private readonly IMapper mapper;
        private HttpResponse<CategoryDTO> response;

        public CategoryServiceAsync(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper)
        {
            this.categoryRepositoryAsync = categoryRepositoryAsync;
            this.mapper = mapper;
            this.response = new HttpResponse<CategoryDTO>();
        }

        public virtual async Task<HttpResponse<CategoryDTO>> CreateAsync(CategoryDTO model, Guid currentId)
        {
            bool isSuccess = false;
            var entity = await categoryRepositoryAsync
                .FindAsync(category => category.Name.Equals(model.Name));


            if (entity.Equals(null))
            {
                isSuccess = await categoryRepositoryAsync.InsertAsync(mapper.Map<Category>(model));
                response.IsSuccess = isSuccess;

                return response;
            }

            response.IsSuccess = isSuccess;

            return response;
        }

        public virtual async Task<HttpResponse<CategoryDTO>> DeleteAsync(Guid Id, Guid currentId)
        {
            bool isSuccess = await categoryRepositoryAsync.RemoveAsync(Id);
            response.IsSuccess = isSuccess;

            return response;
        }

        public virtual async Task<HttpResponse<CategoryDTO>> GetAll()
        {
            var entities = await categoryRepositoryAsync.GetAllAsync(new List<string> { "Specialist" });

            return null;
        }

        public Task<HttpResponse<CategoryDTO>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<CategoryDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<CategoryDTO>> UpdateAsync(CategoryDTO model, Guid currentId)
        {
            throw new NotImplementedException();
        }
    }
}
