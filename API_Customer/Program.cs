using API_Customer.Models;
using API_Customer.Repositories;
using ApiCustomer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Configurando el DBContext para usar el SQL Server
var connectionString = builder.Configuration.GetConnectionString("CustomerDB");
builder.Services.AddDbContext<CustomerDBContext>(options => options.UseSqlServer(connectionString));

//Configurando la inyeccion de dependencia para ICustomerRepository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
