using Microsoft.AspNetCore.Mvc.Filters;
using ProgWeb3.ApiCadastro.Core.Interface;
using ProgWeb3.ApiCadastro.Core.Service;
using ProgWeb3.ApiCadastro.Filters;
using ProgWeb3.ApiCadastro.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GeneralExceptionFilter>();
});

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<CpfExisteActionFilter>();
builder.Services.AddScoped<ValidaUpdateActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
