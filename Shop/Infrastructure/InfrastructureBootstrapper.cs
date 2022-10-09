using Domain.CategoryAgg.Repository;
using Domain.CommentAgg.Repository;
using Domain.OrderAgg.Repository;
using Domain.ProductAgg.Repository;
using Domain.RoleAgg.Repository;
using Domain.SellerAgg.Repository;
using Domain.SiteEntities.Repositories;
using Domain.UserAgg.Repository;
using Infrastructure._Utilities.MediatR;
using Infrastructure.Persistent.Dapper;
using Infrastructure.Persistent.Ef;
using Infrastructure.Persistent.Ef.CategoryAgg;
using Infrastructure.Persistent.Ef.CommentAgg;
using Infrastructure.Persistent.Ef.OrderAgg;
using Infrastructure.Persistent.Ef.ProductAgg;
using Infrastructure.Persistent.Ef.RoleAgg;
using Infrastructure.Persistent.Ef.SellerAgg;
using Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using Infrastructure.Persistent.Ef.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();

        services.AddSingleton<ICustomPublisher, CustomPublisher>();

        services.AddTransient(_ => new DapperContext(connectionString));

        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}