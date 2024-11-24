using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3GroupEFCore.API.Models.Services;
using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : CustomControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateObjectResult(await productService.GetAllList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateObjectResult(await productService.Get(id));
        }

        [HttpGet("WithFeature/{id}")]
        public async Task<IActionResult> GetWithFeature(int id)
        {
            return CreateObjectResult(await productService.GetWithFeature(id));
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddProductRequest request)
        {
            return CreateObjectResult(await productService.AddAsync(request));
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            return CreateObjectResult(await productService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateObjectResult(await productService.DeleteAsync(id));
        }
    }
}