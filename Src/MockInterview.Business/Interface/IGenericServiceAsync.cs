using MockInterview.Domain.Models;

namespace MockInterview.Business.Interface
{
    public interface IGenericServiceAsync<TModel> where TModel : class
    {
        Task<HttpResponse<TModel>> GetAll();

        Task<HttpResponse<TModel>> GetById(Guid id);

        Task<HttpResponse<TModel>> GetPageListAsync(int pageNumber, int pageSize);

        Task<HttpResponse<TModel>> CreateAsync(TModel model, Guid currentId);

        Task<HttpResponse<TModel>> UpdateAsync(TModel model, Guid currentId);

        Task<HttpResponse<TModel>> DeleteAsync(Guid Id, Guid currentId);
    }
}
