using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RevendaApi.Data;
using RevendaApi.Querys;
using RevendaApi.Querys.Implementations;
using RevendaApi.Services;
using RevendaApi.Services.Apis;
using RevendaApi.Services.Implementations;
using RevendaApi.Services.Implementations.Apis;
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

        builder.Services.AddHttpClient();

        builder.Services.AddScoped<BaseQueryParams>();
        builder.Services.AddScoped<IClienteQuery, ClienteQuery>();
        builder.Services.AddScoped<IItemQuery, ItemQuery>();
        builder.Services.AddScoped<IPedidoQuery, PedidoQuery>();
        builder.Services.AddScoped<IRevendaQuery, RevendaQuery>();

        builder.Services.AddScoped<BaseServiceParams>();
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<IPedidoService, PedidoService>();
        builder.Services.AddScoped<IRevendaService, RevendaService>();
        builder.Services.AddScoped<IFabricaService, FabricaService>();
        builder.Services.AddScoped<IFabricaApiService, FabricaApiServiceMock>();

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
