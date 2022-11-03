using Api.Infrastructure;
using Api.Infrastructure.JwtUtil;
using AspNetCoreRateLimit;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Config;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
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
builder.Services.AddDistributedRedisCache(option =>
{
    option.Configuration = "localhost:6379";
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterShopDependency(connectionString);
builder.Services.RegisterApiDependency(builder.Configuration);

CommonBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddJwtAuthentication(builder.Configuration);

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
