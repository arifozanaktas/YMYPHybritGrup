using System.Net;
using YMYPHibrit3GroupEFCore.API.Models.Repositories;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;
using YMYPHibrit3GroupEFCore.API.Models.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Models.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<ServiceResult<List<ProductDto>>> GetAllList()
        {
            var products = await productRepository.GetAsync();


            var productsAsDto = new List<ProductDto>();

            products.ForEach(p =>
                productsAsDto.Add(new ProductDto(p.Id, p.Name, p.Price * 1.2m, p.Stock, null)));


            return ServiceResult<List<ProductDto>>.Success(productsAsDto);
        }

        public async Task<ServiceResult<ProductDto>> Get(int id)
        {
            var product = await productRepository.GetAsync(id);

            if (product == null)
            {
                return ServiceResult<ProductDto>.Failure("Product not found", HttpStatusCode.NotFound);
            }

            var productAsDto = new ProductDto(product.Id, product.Name, product.Price * 1.2m, product.Stock, null);

            return ServiceResult<ProductDto>.Success(productAsDto);
        }

        public async Task<ServiceResult<ProductDto>> GetWithFeature(int id)
        {
            var product = await productRepository.GetWithFeature(id);

            if (product == null)
            {
                return ServiceResult<ProductDto>.Failure("Product not found", HttpStatusCode.NotFound);
            }


            #region bad code

            //var productAsDto = new ProductDto2
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price * 1.2m
            //};


            //if (product.ProductFeature is not null)
            //{
            //    productAsDto.ProductFeatureDto = new ProductFeatureDto(product.ProductFeature.Width, 2, 3);
            //} 

            #endregion


            var productAsDto = new ProductDto(product.Id, product.Name, product.Price * 1.2m, product.Stock, null);


            if (product.ProductFeature is not null)
            {
                productAsDto = productAsDto with
                {
                    ProductFeatureDto = new ProductFeatureDto(product.ProductFeature.Width,
                        product.ProductFeature.Height,
                        product.ProductFeature.Depth)
                };
            }


            return ServiceResult<ProductDto>.Success(productAsDto);
        }


        public async Task<ServiceResult<AddProductResponse>> AddAsync(AddProductRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Barcode = Guid.NewGuid().ToString(),
                Stock = request.Stock
            };


            var newProduct = await productRepository.AddAsync(product);


            var response = new AddProductResponse(newProduct.Id);

            return ServiceResult<AddProductResponse>.Success(response, HttpStatusCode.Created);
        }


        public async Task<ServiceResult> UpdateAsync(UpdateProductRequest request)
        {
            var productToUpdate = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };

            await productRepository.UpdateAsync2(productToUpdate);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }


        public async Task<ServiceResult> DeleteAsync(int id)
        {
            await productRepository.DeleteAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}