using Core.Application.Services.Roles.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Roles
{
    public interface IRolService
    {
        Task<List<GetRolesViewModel>> GetRoles();
        Task<int> CreateRol(CreateRolViewModel rolViewModel);
        Task UpdateRol(int id, JsonPatchDocument<CreateRolViewModel> patchDocument);
        Task SoftDeleteRol(int id);
    }
}
