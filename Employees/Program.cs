using Employees.Domain.Repositories;
using Employees.Infrastructure.Factories;
using Employees.Infrastructure.Factories.Interfaces;
using Employees.Infrastructure.Migrations.Extensions;
using Employees.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnectionFactory, DefaultDbConnectionFactory>();

builder.Services.AddScoped<IPassportRepository, PassportRepository>();

var app = builder.Build();

app.MigrateDatabase<Program>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();