using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Models.Services;

public interface IProductService
{
    Task<ServiceResult<List<ProductDto>>> GetAllList();
    Task<ServiceResult<ProductDto>> Get(int id);
    Task<ServiceResult<ProductDto>> GetWithFeature(int id);
    Task<ServiceResult<AddProductResponse>> AddAsync(AddProductRequest request);
    Task<ServiceResult> UpdateAsync(UpdateProductRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}