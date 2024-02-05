using System.Reflection.Metadata;
using Employees.Application.Contracts.Employee;
using Employees.Application.Contracts.Shared;
using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateRequest dto)
    {
        return Ok(await _service.CreateAsync(new EmployeeDto
        {
            Name = dto.Name,
            CompanyId = dto.CompanyId,
            Phone = dto.Phone,
            Surname = dto.Surname,
            Department = new DepartmentDto
            {
                Name = dto.Department.Name,
                Phone = dto.Department.Phone,
            },
            Passport = new PassportDto
            {
                Number = dto.Passport.Number,
                Type = dto.Passport.Type,
            }
        }));
    }
}