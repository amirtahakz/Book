using Common.Application;
using Common.Domain.ValueObjects;
using Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.AddChild
{
    public record AddChildCategoryCommand(Guid ParentId ,string Title, string Slug, SeoData SeoData) : IBaseCommand<Guid>;
}
