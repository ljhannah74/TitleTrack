using Microsoft.AspNetCore.Mvc;
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
    }
}
