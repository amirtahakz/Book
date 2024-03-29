﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        private ProductImage()
        {

        }
        public ProductImage(string imageName, int sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName , nameof(imageName));
            ImageName = imageName;
            Sequence = sequence;
        }

        public Guid ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Sequence { get; private set; }
    }
}
