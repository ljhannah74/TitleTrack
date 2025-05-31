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

        [HttpGet]
        public async Task<IActionResult> GetAllTitleAbstracts()
        {
            var titleAbstracts = await _titleAbstractRepository.GetAllAsync();
            return Ok(titleAbstracts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTitleAbstractById(int id)
        {
            var titleAbstract = await _titleAbstractRepository.GetByIdAsync(id);

            if (titleAbstract == null)
            {
                return NotFound($"Title Abstract with ID {id} not found.");
            }

            return Ok(titleAbstract);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTitleAbstract([FromBody] TitleAbstract titleAbstract)
        {
            if (titleAbstract == null)
            {
                return BadRequest("Title Abstract cannot be null.");
            }

            await _titleAbstractRepository.AddTitleAbstractAsync(titleAbstract);
            return CreatedAtAction(nameof(GetTitleAbstractById), new { id = titleAbstract.TitleAbstractID }, titleAbstract);
        }

        [HttpGet]
        [Route("orderNo/{orderNo}")]
        
        public async Task<IActionResult> GetTitleAbstractByOrderNo(string orderNo)
        {
            var titleAbstract = await _titleAbstractRepository.GetByOrderNoAsync(orderNo);

            if (titleAbstract == null)
            {
                return NotFound($"Title Abstract with Order No {orderNo} not found.");
            }

            return Ok(titleAbstract);
        }
    }
}
