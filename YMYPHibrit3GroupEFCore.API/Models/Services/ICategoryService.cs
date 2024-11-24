using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Models.Services
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoryDto>> AddAsync(AddCategoryRequest request);
        Task<ServiceResult<int>> AddCategoryWithProductAsync(AddCategoryWithProductRequest request);
        Task<ServiceResult<List<CategoryDto>>> Get();
        Task<ServiceResult<CategoryDto>> Get(int id);
        Task<ServiceResult<CategoryWithProductsDto>> GetWithProductsAsync(int id);
    }
}