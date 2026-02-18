using System;
using Microsoft.AspNetCore.Mvc;
using TitleTrack.Api.Dtos;
using TitleTrack.Api.Entities;
using TitleTrack.Api.Services;

namespace TitleTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AbstractReportsController : ControllerBase
{
    private readonly AbstractReportService _service;

    public AbstractReportsController(AbstractReportService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAbstractReportDto dto)
    {
        try
        {
            var report = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = report.ReportID }, report);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reports = await _service.GetAllAsync();
        return Ok(reports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AbstractReport>> GetById(int id)
    {
        var report = await _service.GetByIdAsync(id);

        if (report == null)
            return NotFound($"AbstractReport with ID '{id}' not found.");

        return Ok(report);
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<AbstractReportDto>>> Search(
    [FromQuery] DateTime? fromDate,
    [FromQuery] DateTime? toDate,
    [FromQuery] int? countyId,
    [FromQuery] string? productType)
    {
        var results = await _service.SearchAsync(fromDate, toDate, countyId, productType);
        return Ok(results);
    }

}
