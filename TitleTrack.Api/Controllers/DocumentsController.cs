using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TitleTrack.Api.Dtos;
using TitleTrack.Api.Services;

namespace TitleTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _service;

        public DocumentsController(DocumentService service)
        {
            _service = service;
        }

        [HttpGet("by-abstract/{abstractReportId:int}")]
        public async Task<ActionResult<List<DocumentDto>>> GetByAbstractReport(int abstractReportId)
        {
            var documents = await _service.GetByAbstractReportAsync(abstractReportId);
            return Ok(documents);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentDto>> Create(DocumentDto dto)
        {
            try
            {
                var created = await _service.CreatAsync(dto);
                return CreatedAtAction(nameof(GetByAbstractReport), new { abstractReportId = created.AbstractReportId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
