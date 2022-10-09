using Common.Query;

namespace Query.Orders.DTOs;

public class OrderItemDto : BaseDto
{
    public string ProductTitle { get; set; }
    public string ProductSlug { get; set; }
    public string ProductImageName { get; set; }
    public string ShopName { get; set; }
    public Guid OrderId { get; set; }
    public Guid InventoryId { get; set; }
    public int Count { get; set; }
    public long Price { get; set; }
    public long TotalPrice => Price * Count;
}