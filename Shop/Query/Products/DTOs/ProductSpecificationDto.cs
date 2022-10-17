using Common.Query;

namespace Query.Products.DTOs;

public class ProductSpecificationDto : BaseDto
{
    public string Key { get; set; }
    public string Value { get; set; }
}