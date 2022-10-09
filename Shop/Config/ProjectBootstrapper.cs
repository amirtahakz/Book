using Microsoft.Extensions.DependencyInjection;

namespace Config
{
    public static class ProjectBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            //InfrastructureBootstrapper.Init(services, connectionString);

            //services.AddMediatR(typeof(Directories).Assembly);

            //services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            //services.AddTransient<IProductDomainService, ProductDomainService>();
            //services.AddTransient<IUserDomainService, UserDomainService>();
            //services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            //services.AddTransient<ISellerDomainService, SellerDomainService>();


            //services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

            //services.InitFacadeDependency();
        }
    }
}