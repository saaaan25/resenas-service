using reseñas.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using DotNetEnv;
using reseñas.Interfaces;
using reseñas.Repository;
using reseñas.Services;
using Microsoft.AspNetCore.HttpOverrides;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? throw new InvalidOperationException("DATABASE_URL environment variable is not set.");

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddHttpClient<SyncService>();

builder.Services.AddScoped<IResenaRepository, ResenaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<IOrdenItemRepository, OrdenItemRepository>();
builder.Services.AddScoped<ISyncService, SyncService>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Adapt base url
var forwardedHeadersOptions = new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeadersOptions.KnownNetworks.Clear();
forwardedHeadersOptions.KnownProxies.Clear();

app.UseForwardedHeaders(forwardedHeadersOptions);

// Allow docs in production
if (builder.Configuration.GetValue<bool>("EnableDocs"))
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

Console.WriteLine("EnableDocs=" + builder.Configuration["EnableDocs"]);

app.UseHttpsRedirection();

app.MapControllers();

app.Run();