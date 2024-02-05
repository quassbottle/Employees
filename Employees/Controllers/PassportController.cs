using Employees.Application.Contracts.Passport;
using Employees.Application.Contracts.Shared;
using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PassportController : Controller
{
    private readonly IPassportService _service;

    public PassportController(IPassportService service)
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
    public async Task<IActionResult> Create(PassportCreateRequest dto)
    {
        return Ok(await _service.CreateAsync(new PassportDto
        {
            Type = dto.Type,
            Number = dto.Number,
        }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, PassportUpdateRequest dto)
    {
        if (dto.Type is null && dto.Number is null)
        {
            return BadRequest(new ExceptionResponse
            {
                Status = 400,
                Message = "Invalid parameters",
            });
        }
        
        await _service.UpdateAsync(new PassportDto
        {
            Type = dto.Type,
            Number = dto.Number,
        }, id);
        
        return Ok();
    }   
}