using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Infrastructure.Repository
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>,  ICategoryRepositoryAsync
    {
        public readonly DbSet<Category> categories;

        public CategoryRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this.categories = context.Categories;
        }
    }
}
