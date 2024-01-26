using Core.Application.Services.Characters;
using Core.Application.Services.Characters.ViewModels;
using Core.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharactersController(ICharacterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCharactersViewModel>>> GetAll()
        {
            return await _service.GetCharacters();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDetailsViewModel>> GetById(int id)
        {
            return await _service.GetCharacterDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateCharacterViewModel character)
        {
            return await _service.CreateCharacter(character);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<CreateCharacterViewModel> patchDocument)
        {
            await _service.UpdateCharacter(id, patchDocument);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            await _service.SoftDeleteCharacter(id);

            return NoContent();
        }
    }
}
