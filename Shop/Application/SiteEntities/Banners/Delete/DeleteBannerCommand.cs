using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteEntities.Banners.Delete
{
    public record DeleteBannerCommand(Guid Id) : IBaseCommand;
}
