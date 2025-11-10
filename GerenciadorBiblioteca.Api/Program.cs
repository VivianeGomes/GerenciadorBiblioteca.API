using GerenciadorBiblioteca.Api.Interfaces;
using GerenciadorBiblioteca.Api.Mappings;
using GerenciadorBiblioteca.Api.Services;
using GerenciadorBiblioteca.Domain.Interfaces;
using GerenciadorBiblioteca.Infra.Repositories;
using GerenciadorBiblioteca.Infra.Services;
using GerenciadorBiblioteca.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(LivroProfile).Assembly);

builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseInMemoryDatabase("BibliotecaDb"));

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
