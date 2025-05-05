using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TitleTrackAPI.Models;
using TitleTrackAPI.Repositories;

namespace TitleTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleAbstractController : ControllerBase
    {
        private readonly ITitleAbstractRepository _titleAbstractRepository;
        public TitleAbstractController(ITitleAbstractRepository titleAbstractRepository)
        {
            _titleAbstractRepository = titleAbstractRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTitleAbstract(TitleAbstract titleAbstract)
        {
            if (titleAbstract == null)
            {
                return BadRequest("Title Abstract is null.");
            }

            await _titleAbstractRepository.AddTitleAbstractAsync(titleAbstract);
            return CreatedAtAction(nameof(GetAllTitleAbstracts), new { id = titleAbstract.TitleAbstractID }, titleAbstract);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTitleAbstracts()
        {
            var titleAbstracts = await _titleAbstractRepository.GetAllAsync();
            return Ok(titleAbstracts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitleAbstractById(int id)
        {
            var titleAbstract = await _titleAbstractRepository.GetByIdAsync(id);
            if (titleAbstract == null)
            {
                return NotFound($"Title Abstract with ID {id} not found.");
            }
            return Ok(titleAbstract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTitleAbstract(int id, TitleAbstract titleAbstract)
        {
            if (id != titleAbstract.TitleAbstractID)
            {
                return BadRequest("ID mismatch.");
            }

            var existingTitleAbstract = await _titleAbstractRepository.GetByIdAsync(id);
            if (existingTitleAbstract == null)
            {
                return NotFound($"Title Abstract with ID {id} not found.");
            }

            await _titleAbstractRepository.UpdateTitleAbstractAsync(titleAbstract);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitleAbstract(int id)
        {
            var titleAbstract = await _titleAbstractRepository.GetByIdAsync(id);
            if (titleAbstract == null)
            {
                return NotFound($"Title Abstract with ID {id} not found.");
            }

            await _titleAbstractRepository.DeleteTitleAbstractAsync(id);
            return NoContent();
        }
    }
}
