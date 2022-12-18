using AutoMapper;
using Microsoft.AspNetCore.Http;
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


            if (entity is null)
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

        public virtual async Task<HttpResponse<CategoryDTO>> GetAllAsync()
        {
            var entities = await categoryRepositoryAsync.GetAllAsync(new List<string> { "Specialist" });
            response.Result = mapper.Map<IEnumerable<CategoryDTO>>(entities);

            return response;
        }

        public virtual async Task<HttpResponse<CategoryDTO>> GetByIdAsync(Guid id)
        {
            var category = await categoryRepositoryAsync.FindAsync(category => category.Id == id);
            response.Result = new List<CategoryDTO>() { mapper.Map<CategoryDTO>(category) };

            return response;

        }

        public virtual async Task<HttpResponse<CategoryDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var categories = await categoryRepositoryAsync.GetPageListAsync(pageNumber, pageSize);
            response.TotalCount = categories.count;
            response.Result = mapper.Map<IEnumerable<CategoryDTO>>(categories.entities);

            return response;
        }

        public virtual async Task<HttpResponse<CategoryDTO>> UpdateAsync(CategoryDTO model, Guid currentId)
        {
            var existCategory = await categoryRepositoryAsync
                .FindAsync(category => category.Id.Equals(model.Id));

            if(existCategory is not null)
            {
                var category = mapper.Map<Category>(model);
                await categoryRepositoryAsync.UpdateAsync(category);
            }
            else
            {
                response.IsSuccess = false;
                response.StatusMessage = "This category is not";
                response.StatusCode = StatusCodes.Status400BadRequest;
            }

            return response;
        }
    }
}
