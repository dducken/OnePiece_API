using Core.Application.Services.Characters.ViewModels;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services.Roles.ViewModels
{
    public class GetRolesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator GetRolesViewModel(Rol rol)
       => new GetRolesViewModel
       {
           Id = rol.Id,
           Name = rol.Name,
       };
    }
}
