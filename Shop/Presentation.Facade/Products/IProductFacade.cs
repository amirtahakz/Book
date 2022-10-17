using Application.Products.AddImage;
using Application.Products.Create;
using Application.Products.Edit;
using Application.Products.RemoveImage;
using Common.Application;
using Query.Products.DTOs;
using Query.Sellers.DTOs;

namespace Presentation.Facade.Products;

public interface IProductFacade
{
    Task<OperationResult> CreateProduct(CreateProductCommand command);
    Task<OperationResult> EditProduct(EditProductCommand command);
    Task<OperationResult> AddImage(AddProductImageCommand command);
    Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

    Task<ProductDto?> GetProductById(Guid productId);
    Task<ProductDto?> GetProductBySlug(string slug);
    Task<SingleProductDto?> GetProductBySlugForSinglePage(string slug);
    Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
    Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);
}

public class SingleProductDto
{
    public ProductDto ProductDto { get; set; }
    public List<InventoryDto> Inventories { get; set; }
}