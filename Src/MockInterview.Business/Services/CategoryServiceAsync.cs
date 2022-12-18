using AutoMapper;
using MockInterview.Business.Interface;
using MockInterview.Domain.Entities;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.CategoryDTO;
using MockInterview.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterview.Business.Services
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        private readonly IMapper mapper;
        private HttpResponse<CategoryDTO> response;

        public CategoryServiceAsync(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper, HttpResponse<CategoryDTO> response)
        {
            this.categoryRepositoryAsync = categoryRepositoryAsync;
            this.mapper = mapper;
            this.response = new HttpResponse<CategoryDTO>();
        }

        public virtual async Task<HttpResponse<CategoryDTO>> Create(CategoryDTO model)
        {
            var entity = mapper
                .Map<Category>(await categoryRepositoryAsync
                .FindAsync(category => category.Name.Equals(model.Name)));

            bool isSuccess = false;

            if (!entity.Equals(null))
            {
                isSuccess = categoryRepositoryAsync.UpdateAsync(entity);
                response.IsSuccess = isSuccess;

                return response;
            }

            response.IsSuccess = isSuccess;

            return response;
        }

        public Task<HttpResponse<CategoryDTO>> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<CategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<CategoryDTO>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<CategoryDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<CategoryDTO>> Update(CategoryDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
