using Microsoft.EntityFrameworkCore;
using System.Net;
using YMYPHibrit3GroupEFCore.API.Models.Repositories;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;
using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Models.Services
{
    public class CategoryService(
        ICategoryRepository categoryRepository,
        IGenericRepository<Product> productRepository,
        IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<ServiceResult<List<CategoryDto>>> Get()
        {
            var categories = await categoryRepository.GetAsync();
            if (categories == null)
            {
                return ServiceResult<List<CategoryDto>>.Success(Enumerable.Empty<CategoryDto>().ToList());
            }


            //List<CategoryDto> categoryDtos = new();
            //foreach (var p in product)
            //{
            //    categoryDtos.Add(new CategoryDto(p.Id, p.Name));
            //}

            var categoryDtos = categories.Select(p => new CategoryDto(p.Id, p.Name)).ToList();

            return ServiceResult<List<CategoryDto>>.Success(categoryDtos);
        }

        public async Task<ServiceResult<CategoryDto>> Get(int id)
        {
            var category = await categoryRepository.GetAsync(id);
            if (category == null)
            {
                return ServiceResult<CategoryDto>.Failure("Category not found", HttpStatusCode.NotFound);
            }

            var categoryDto = new CategoryDto(category.Id, category.Name);

            return ServiceResult<CategoryDto>.Success(categoryDto);
        }

        public async Task<ServiceResult<CategoryDto>> AddAsync(AddCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            categoryRepository.Add(category);

            await unitOfWork.SaveChangesAsync();
            return ServiceResult<CategoryDto>.Success(new CategoryDto(category.Id, category.Name),
                HttpStatusCode.Created);
        }

        public async Task<ServiceResult<int>> AddCategoryWithProductAsync(AddCategoryWithProductRequest request)

        {
            var category = new Category()
            {
                Name = request.CategoryName
            };

            category.Products = new();
            category.Products.Add(new Product()
            {
                Name = request.ProductName,
                Price = request.ProductPrice,
                Barcode = Guid.NewGuid().ToString(),
                Stock = request.ProductStock
            });

            categoryRepository.Add(category);


            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.Success(category.Id, HttpStatusCode.Created);


            #region 1.way

            //using (var transaction = await unitOfWork.BeginTransactionAsync())
            //{
            //    var category = new Category
            //    {
            //        Name = request.CategoryName
            //    };

            //    categoryRepository.Add(category);
            //    await unitOfWork.SaveChangesAsync();


            //    var product = new Product
            //    {

            //        Name = request.ProductName,
            //        Price = request.ProductPrice,
            //        Barcode = Guid.NewGuid().ToString(),
            //        Stock = request.ProductStock,
            //        CategoryId = category.Id
            //    };

            //    productRepository.Add(product);


            //    await unitOfWork.SaveChangesAsync();

            //    //await unitOfWork.CommitAsync();
            //    await transaction.CommitAsync();


            //    return ServiceResult<int>.Success(category.Id,HttpStatusCode.Created);
            //} 

            #endregion
        }


        public async Task<ServiceResult<CategoryWithProductsDto>> GetWithProductsAsync(int id)
        {
            #region 1.way (bad way)

            //var category =await categoryRepository.GetAsync(id);

            //var products = await productRepository.Where(p => p.CategoryId == id).OrderByDescending(x => x.Price).ToListAsync();

            #endregion


            var category = await categoryRepository.GetWithProductsAsync(id);


            if (category is null)
            {
                return ServiceResult<CategoryWithProductsDto>.Failure("Category not found", HttpStatusCode.NotFound);
            }


            var categoryWithProducts = new CategoryWithProductsDto();

            categoryWithProducts.Id = category.Id;
            categoryWithProducts.Name = category.Name;


            if (category.Products is not null && category.Products.Count > 0)
            {
                categoryWithProducts.Products = category.Products
                    .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, null)).ToList();
            }


            return ServiceResult<CategoryWithProductsDto>.Success(categoryWithProducts);
        }
    }
}