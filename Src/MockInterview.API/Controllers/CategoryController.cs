using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.CategoryDTO;

namespace MockInterview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync categoryServiceAsync)
        {
            this.categoryServiceAsync = categoryServiceAsync;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse<CategoryDTO>), 200)]
        public virtual async Task<IActionResult> GetCategoryAsync()
        {
            var response = await categoryServiceAsync.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }
    }
}
