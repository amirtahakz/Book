using Api.Infrastructure.Security;
using Api.ViewModels.Products;
using Application.Products.AddImage;
using Application.Products.Create;
using Application.Products.Edit;
using Application.Products.RemoveImage;
using Common.AspNetCore;
using Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Products;
using Query.Products.DTOs;

namespace Api.Controllers;

[PermissionChecker(Permission.CRUD_Product)]
public class ProductController : ApiController
{
    private readonly IProductFacade _productFacade;

    public ProductController(IProductFacade productFacade)
    {
        _productFacade = productFacade;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
    {
        return QueryResult(await _productFacade.GetProductsByFilter(filterParams));
    }
    [AllowAnonymous]
    [HttpGet("Shop")]
    public async Task<ApiResult<ProductShopResult>> GetProductForShopFilter([FromQuery] ProductShopFilterParam filterParams)
    {
        return QueryResult(await _productFacade.GetProductsForShop(filterParams));
    }

    [AllowAnonymous]
    [HttpGet("{productId}")]
    public async Task<ApiResult<ProductDto?>> GetProductById(Guid productId)
    {
        var product = await _productFacade.GetProductById(productId);
        return QueryResult(product);
    }

    [AllowAnonymous]
    [HttpGet("bySlug/{slug}")]
    public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
    {
        var product = await _productFacade.GetProductBySlug(slug);
        return QueryResult(product);
    }

    [AllowAnonymous]
    [HttpGet("single/{slug}")]
    public async Task<ApiResult<SingleProductDto?>> GetSingleProduct(string slug)
    {
        var product = await _productFacade.GetProductBySlugForSinglePage(slug);
        return QueryResult(product);
    }

    [HttpPost]
    public async Task<ApiResult> CreateProduct([FromForm] CreateProductViewModel viewModel)
    {
        var result = await _productFacade.CreateProduct(new CreateProductCommand(viewModel.Title , viewModel.ImageFile ,viewModel.Description , viewModel.CategoryId , viewModel.SubCategoryId ,
            viewModel.SecondarySubCategoryId ,viewModel.Slug , viewModel.SeoData.Map() , viewModel.GetSpecification()));
        //var result = await _productFacade.CreateProduct(new CreateProductCommand()
        //{
        //    SeoData = viewModel.SeoData.Map(),
        //    CategoryId = viewModel.CategoryId,
        //    Description = viewModel.Description,
        //    ImageFile = viewModel.ImageFile,
        //    SecondarySubCategoryId = viewModel.SecondarySubCategoryId,
        //    Slug = viewModel.Slug,
        //    Specifications = viewModel.GetSpecification(),
        //    SubCategoryId = viewModel.SubCategoryId,
        //    Title = viewModel.Title
        //});
        return CommandResult(result);
    }

    [HttpPost("images")]
    public async Task<ApiResult> AddImage([FromForm] AddProductImageCommand command)
    {
        var result = await _productFacade.AddImage(command);
        return CommandResult(result);
    }

    [HttpDelete("images")]
    public async Task<ApiResult> RemoveImage(RemoveProductImageCommand command)
    {
        var result = await _productFacade.RemoveImage(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> EditProduct([FromForm] EditProductViewModel viewModel)
    {
        var result = await _productFacade.EditProduct(new EditProductCommand(viewModel.ProductId, viewModel.Title, viewModel.ImageFile,
            viewModel.Description, viewModel.CategoryId, viewModel.SubCategoryId, viewModel.SecondarySubCategoryId, viewModel.Slug, viewModel.SeoData.Map(),
            viewModel.GetSpecification()));
        return CommandResult(result);
    }
}