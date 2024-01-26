using Core.Application.Services.Characters.ViewModels;
using Core.Application.Services.Characters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Services.Roles;
using Core.Application.Services.Roles.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _service;

        public RolesController(IRolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetRolesViewModel>>> GetAll()
        {
            return await _service.GetRoles();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateRolViewModel rol)
        {
            return await _service.CreateRol(rol);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<CreateRolViewModel> patchDocument)
        {
            await _service.UpdateRol(id, patchDocument);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            await _service.SoftDeleteRol(id);

            return NoContent();
        }
    }
}
