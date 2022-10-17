using Application._Utilities;
using Application.Categories;
using Application.Products;
using Application.Roles.Create;
using Application.Sellers;
using Application.Users;
using Domain.CategoryAgg.Services;
using Domain.ProductAgg.Services;
using Domain.SellerAgg.Services;
using Domain.UserAgg.Services;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Facade;
using Query.Categories.GetById;

namespace Config
{
    public static class ProjectBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(typeof(Directories).Assembly);

            services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();


            services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

            services.InitFacadeDependency();
        }
    }
}