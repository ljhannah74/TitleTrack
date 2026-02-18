using System;
using Microsoft.AspNetCore.Mvc;
using TitleTrack.Api.Dtos;
using TitleTrack.Api.Services;

namespace TitleTrack.Api.Controllers;

public class CountiesController : ControllerBase
{
   private readonly CountyService _service;

    public CountiesController(CountyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var counties = await _service.GetAllAsync();
        return Ok(counties);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CountyDto dto)
    {
        var county = await _service.CreateAsync(dto.Name, dto.State);
        return CreatedAtAction(nameof(GetAll), new { id = county.CountyID }, county);
    }
}
