using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using YMYPHibrit3Group.API.Filters;
using YMYPHibrit3Group.API.Model.Services;
using YMYPHibrit3Group.API.Model.Services.Dto;

namespace YMYPHibrit3Group.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : CustomControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [MyActionFilter]
    //[PerformanceResourceFilter]
    [MyResourceFilter]
    [HttpGet]
    public IActionResult GetProducts()
    {
        var result = _productService.GetAll();
        Thread.Sleep(5000);

        return CreateObjectResult(result);
    }

    [HttpGet("{productId:int}")]
    public IActionResult GetProduct(int productId)
    {
        var result = _productService.GetById(productId);
        return CreateObjectResult(result);
    }


    [HttpGet("{pageSize:int}/{pageCount:int}")]
    public IActionResult GetPagedProduct(int pageSize, int pageCount)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult AddProduct(AddProductRequest request)
    {
        var result = _productService.Add(request);


        return CreateObjectResult(result);
    }

    [ServiceFilter<NotFoundProductFilter>]
    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductRequest request)
    {
        var result = _productService.Update(request);

        return CreateObjectResult(result);
    }


    [HttpPatch("stock")]
    public IActionResult UpdateProductStock(UpdateProductStockRequest request)
    {
        var result = _productService.UpdateStock(request.ProductId, request.Stock);


        return CreateObjectResult(result);
    }


    [HttpPatch("price")]
    public IActionResult UpdateProductPrice(UpdateProductPriceRequest request)
    {
        var result = _productService.UpdatePrice(request.ProductId, request.Price);


        return CreateObjectResult(result);
    }

    [ServiceFilter<NotFoundProductFilter>]
    [HttpDelete("{productId:int}")]
    public IActionResult DeleteProduct(int productId)
    {
        var result = _productService.Delete(productId);


        return CreateObjectResult(result);
    }
}