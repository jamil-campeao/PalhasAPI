using Microsoft.EntityFrameworkCore;
using PalhasAPI.Application.Clientes.Commands.CriarCliente;
using PalhasAPI.Domain.Interfaces;
using PalhasAPI.Infrastructure.Persistence;
using PalhasAPI.Infrastructure.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PalhasDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CriarClienteCommand).Assembly));
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
