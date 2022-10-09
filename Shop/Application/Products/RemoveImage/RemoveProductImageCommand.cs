using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.RemoveImage
{
    public record RemoveProductImageCommand(Guid ProductId, Guid ImageId) : IBaseCommand;
}
