using Api.Infrastructure;
using Api.Infrastructure.JwtUtil;
using AspNetCoreRateLimit;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Microsoft.OpenApi.Models;
using Config;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers()
    .ConfigureApiBehaviorOptions(option =>
    {
        option.InvalidModelStateResponseFactory = (context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = AppStatusCode.BadRequest,
                    Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                }
            };
            return new BadRequestObjectResult(result);
        });
    });
services.AddDistributedRedisCache(option =>
{
    option.Configuration = "localhost:6379";
});
services.AddEndpointsApiExplorer();
//services.AddSwaggerGen(option =>
//{
//    var jwtSecurityScheme = new OpenApiSecurityScheme
//    {
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        Name = "JWT Authentication",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Description = "Enter Token",

//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }
//    };

//    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        { jwtSecurityScheme, Array.Empty<string>() }
//    });
//});
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiAuthorize", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insert Your Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
    }
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

services.RegisterShopDependency(connectionString);
services.RegisterApiDependency(builder.Configuration);

CommonBootstrapper.Init(services);
services.AddTransient<IFileService, FileService>();

services.AddJwtAuthentication(builder.Configuration);



var app = builder.Build();


app.UseIpRateLimiting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("ShopApi");

app.UseAuthentication();

app.UseAuthorization();

app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
