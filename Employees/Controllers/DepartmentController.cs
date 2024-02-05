using Employees.Application.Contracts.Shared;
using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DepartmentController : Controller
{
    private readonly IDepartmentService _service;

    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentCreateRequest dto)
    {
        return Ok(await _service.CreateAsync(new DepartmentDto
        {
            Name = dto.Name,
            Phone = dto.Phone,
        }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, DepartmentUpdateRequest dto)
    {
        if (dto.Name is null && dto.Phone is null)
        {
            return BadRequest(new ExceptionResponse
            {
                Status = 400,
                Message = "Bad parameters",
            });
        }
        
        await _service.UpdateAsync(new DepartmentDto
        {
            Name = dto.Name,
            Phone = dto.Phone,
        }, id);
        
        return Ok();
    }
}