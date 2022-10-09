using Common.Domain.ValueObjects;
using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Create
{
    public class CreateProductCommand : IBaseCommand
    {
        public CreateProductCommand(string title, IFormFile imageFile, string description, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }

        public string Title { get;private set; }
        public IFormFile ImageFile { get;private set; }
        public string Description { get;private set; }
        public Guid CategoryId { get;private set; }
        public Guid SubCategoryId { get;private set; }
        public Guid SecondarySubCategoryId { get;private set; }
        public string Slug { get;private set; }
        public SeoData SeoData { get;private set; }
        public Dictionary<string, string> Specifications { get;private set; }
    }
}
