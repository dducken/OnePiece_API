using Core.Application.Services.Pirates;
using Core.Application.Services.Pirates.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/pirates")]
    public class PiratesController : ControllerBase
    {
        private readonly IPirateService _service;

        public PiratesController(IPirateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPiratesViewModel>>> GetAll()
        {
            return await _service.GetPirates();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPirateDetailsViewModel>> GetById(int id)
        {
            return await _service.GetPirateDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreatePirateViewModel pirate)
        {
            return await _service.CreatePirate(pirate);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<CreatePirateViewModel> patchDocument)
        {
            await _service.UpdatePirate(id, patchDocument);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            await _service.SoftDeletePirate(id);

            return NoContent();
        }
    }
}
