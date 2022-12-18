using MockInterview.Domain.Models;

namespace MockInterview.Business.Interface
{
    public interface IGenericServiceAsync<TModel> where TModel : class
    {
        Task<HttpResponse<TModel>> GetAll();

        Task<HttpResponse<TModel>> GetById(Guid id);

        Task<HttpResponse<TModel>> GetPageListAsync(int pageNumber, int pageSize);

        Task<HttpResponse<TModel>> CreateAsync(TModel model);

        Task<HttpResponse<TModel>> UpdateAsync(TModel model);

        Task<HttpResponse<TModel>> DeleteAsync(Guid Id);
    }
}
