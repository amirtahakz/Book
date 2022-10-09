using Common.Application;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Domain.CategoryAgg;
using Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Create
{
    public record EditCategoryCommand(string Slug, string Title, SeoData SeoData, ICategoryDomainService Service) : IBaseCommand<Guid>;
}
