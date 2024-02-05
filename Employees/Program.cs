using Employees.Application.Services;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Factories;
using Employees.Infrastructure.Factories.Interfaces;
using Employees.Infrastructure.Migrations.Extensions;
using Employees.Infrastructure.Repositories;
using Employees.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionFactory, DefaultDbConnectionFactory>();

builder.Services.AddScoped<IPassportRepository, PassportRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

app.MigrateDatabase<Program>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();