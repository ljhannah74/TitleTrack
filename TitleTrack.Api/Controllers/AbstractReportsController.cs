using System;
using Microsoft.AspNetCore.Mvc;
using TitleTrack.Api.Dtos;
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
        var report = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = report.ReportID }, report);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reports = await _service.GetAllAsync();
        return Ok(reports);
    }
}
