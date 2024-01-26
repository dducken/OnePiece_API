using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Services.Characters.ViewModels;
using Core.Application.Services.Roles.ViewModels;
using Core.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Roles
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET ALL
        public async Task<List<GetRolesViewModel>> GetRoles()
        {
            var roles = _unitOfWork.Roles.GetQuery(filter: rol => rol.Deleted == null);

            return await roles
                .Select(rol => (GetRolesViewModel)rol).ToListAsync();
        }

        // CREATE
        public async Task<int> CreateRol(CreateRolViewModel rolViewModel)
        {
            var rol = new Rol
            {
                Name = rolViewModel.Name,
            };

            _unitOfWork.Roles.Add(rol);
            await _unitOfWork.CompleteAsync();

            return rol.Id;
        }

        // PATCH (Update)
        public async Task UpdateRol(int id, JsonPatchDocument<CreateRolViewModel> patchDocument)
        {
            var rol = await _unitOfWork.Roles.FindAsync(rol => rol.Id == id,
                filter: rol => rol.Deleted == null);

            if (rol == null)
                throw new NotFoundException(nameof(Rol), id);

            var rolViewModel = new CreateRolViewModel
            {
                Name = rol.Name,
            };

            patchDocument.ApplyTo(rolViewModel);

            rol.Name = rolViewModel.Name;

            _unitOfWork.Roles.Patch(rol);
            await _unitOfWork.CompleteAsync();
        }

        // SOFT DELETE
        public async Task SoftDeleteRol(int id)
        {
            var rol = await _unitOfWork.Roles.FindAsync(rol => rol.Id == id,
                filter: rol => rol.Deleted == null);

            if (rol is null)
                throw new NotFoundException(nameof(Rol), id);

            _unitOfWork.Roles.Delete(rol);
            await _unitOfWork.CompleteAsync();
        }
    }
}
