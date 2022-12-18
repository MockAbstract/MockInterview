using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockInterview.Business.Interface;
using MockInterview.Domain.Models;
using MockInterview.Domain.Models.CategoryDTO;
using System.Security.Claims;

namespace MockInterview.API.Controllers
{
    [Route("category-management/category")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;

        public CategoryController(ICategoryServiceAsync categoryServiceAsync)
        {
            this.categoryServiceAsync = categoryServiceAsync;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpResponse<CategoryDTO>), 200)]
        public async Task<IActionResult> GetCategoryAsync()
        {
            var response = await categoryServiceAsync.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(HttpResponse<CategoryDTO>), 200)]
        public async Task<IActionResult> GetCategoryByIdAsync([FromQuery] Guid id)
        {
            var response = await categoryServiceAsync.GetByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("page")]
        [ProducesResponseType(typeof(HttpResponse<CategoryDTO>), 200)]
        public async Task<IActionResult> GetCategoryPageAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await categoryServiceAsync
                .GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(HttpResponse<CategoryDTO>), 200)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var clientId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await categoryServiceAsync.DeleteAsync(id, clientId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(CategoryForUpdateDTO category)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await categoryServiceAsync.UpdateAsync(category, employeeId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(CategoryForCreationDTO category)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var employeeId = Guid
                .Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);

            var response = await categoryServiceAsync.CreateAsync(category, Guid.NewGuid());

            return StatusCode(response.StatusCode, response);
        }
    }
}
