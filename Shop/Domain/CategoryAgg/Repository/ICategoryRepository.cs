using Common.Domain.Repository;
using Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CategoryAgg.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> DeleteCategory(Guid categoryId);
    }
}
