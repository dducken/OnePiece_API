using Core.Application.Services.Pirates.ViewModels;
using Core.Application.Services.Roles.ViewModels;
using Core.Domain.Models;

namespace Core.Application.Services.Characters.ViewModels
{
    public class GetCharacterMinDetailsViewModel
    {
        public int Id { get; set; }
   
        public string FullName { get; set; }

        public string? ImageURL { get; set; }

        //public static explicit operator GetCharacterMinDetailsViewModel(Character character)
        //  => new GetCharacterMinDetailsViewModel
        //  {
        //      Id = character.Id,
        //      FullName = character.FullName,
        //      ImageURL = character.ImageURL,
        //      Rol = new GetRolesViewModel { Id = character.Rol.Id,Name = character.Rol.Name },
           
        //  };
    }
}
