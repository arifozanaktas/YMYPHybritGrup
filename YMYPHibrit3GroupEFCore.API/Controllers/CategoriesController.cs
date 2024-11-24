using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3GroupEFCore.API.Models.Repositories;
using YMYPHibrit3GroupEFCore.API.Models.Services;
using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService,ICategoryRepository categoryRepository) : CustomControllerBase
    {

        [HttpPost("WithProduct")]
        public async Task<IActionResult>  AddCategoryWithProduct(AddCategoryWithProductRequest request)
        {

            var result = await categoryService.AddCategoryWithProductAsync(request);

            return CreateObjectResult(result);
        }

        [HttpGet("WithProducts/{id}")]
        public async Task<IActionResult> GetCategoryWithProduct(int id)
        {

            var result = await categoryService.GetWithProductsAsync(id);

            return CreateObjectResult(result);
        }

        [HttpGet("WithProducts/LinqQuery/{id}")]
        public async Task<IActionResult> GetCategoryWithProductLinqQuery(int id)
        {

            var (category,products) = await categoryRepository.GetWithProductsAsyncAsLinqQuery(id);

            return Ok();
        }

    }
}
