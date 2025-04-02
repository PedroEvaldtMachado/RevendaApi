using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RevendaApi.Data;
using RevendaApi.Querys;
using RevendaApi.Querys.Implementations;
using RevendaApi.Services;
using RevendaApi.Services.Implementations;
using Scalar.AspNetCore;
using System;

namespace RevendaApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        if (!builder.Configuration.GetSection("UseInMemoryDatabase").Get<bool>())
        { 
            builder.Services.AddEntityFrameworkNpgsql();
            builder.Services.AddDbContext<AppDbContext>(cfg => cfg.UseNpgsql(builder.Configuration.GetRequiredSection("ConnectionStrings:DefaultConnection").Get<string>()));
            builder.Services.AddDbContext<NoTrackingDbContext>(cfg => cfg.UseNpgsql(builder.Configuration.GetRequiredSection("ConnectionStrings:DefaultConnection").Get<string>()));
        }
        else
        {
            builder.Services.AddDbContext<AppDbContext>(cfg => cfg.UseInMemoryDatabase("RevendaApi"));
            builder.Services.AddDbContext<NoTrackingDbContext>(cfg => cfg.UseInMemoryDatabase("RevendaApi"));
        }

        builder.Services.AddScoped(typeof(Lazy<>));

        builder.Services.AddScoped<BaseQueryParams>();
        builder.Services.AddScoped<IRevendaQuery, RevendaQuery>();

        builder.Services.AddScoped<BaseServiceParams>();
        builder.Services.AddScoped<IRevendaService, RevendaService>();

        builder.Services.AddControllers();
        builder.Services.AddAuthorization();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapOpenApi();
        app.MapScalarApiReference(options => options.Servers = Array.Empty<ScalarServer>());

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
