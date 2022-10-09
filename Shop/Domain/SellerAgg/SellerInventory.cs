using Common.Domain;
using Common.Domain.Exceptions;

namespace Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        private SellerInventory()
        {

        }
        public SellerInventory(Guid productId, int count, long price, int? discountPercentage = null)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();

            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }

        public Guid SellerId { get; internal set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }
        public long Price { get; private set; }
        public int? DiscountPercentage { get; private set; }

        public void Edit(int count, int price, int? discountPercentage = null)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException();

            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
    }
}
