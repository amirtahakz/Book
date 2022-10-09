using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.AddImage
{
    public class AddProductImageCommand : IBaseCommand
    {

        public IFormFile ImageFile { get; set; }
        public Guid ProductId { get; set; }
        public int Sequence { get; set; }
    }
}
