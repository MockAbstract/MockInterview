namespace MockInterview.Domain.Models
{
    public class HttpResponse<TEntity> where TEntity : class
    {
        public int TotalCount { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public int StatusCode { get; set; } = 200;
        public string StatusMessage { get; set; } = null;
    }
}
