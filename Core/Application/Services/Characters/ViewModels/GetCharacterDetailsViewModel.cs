using Core.Application.Services.Pirates.ViewModels;
using Core.Application.Services.Roles.ViewModels;
using Core.Domain.Models;

namespace Core.Application.Services.Characters.ViewModels
{
    public class GetCharacterDetailsViewModel
    {
        public int Id { get; set; }
   
        public string FullName { get; set; }

        public int Age { get; set; }

        public string? Origin { get; set; }

        public string? Reward { get; set; }

        public double Height { get; set; }

        public string? ImageURL { get; set; }
        public GetPiratesViewModel Pirate { get; set; }
        public GetRolesViewModel Rol { get; set; }

        public static explicit operator GetCharacterDetailsViewModel(Character character)
          => new GetCharacterDetailsViewModel
          {
              Pirate = new GetPiratesViewModel { 
                  Id = character.PirateId,
                  Name = character.Pirate.Name,
                  Ship = character.Pirate.Ship,
                  TotalReward = character.Pirate.TotalReward,
                  ImageURL = character.ImageURL,
              },
              Id = character.Id,
              FullName = character.FullName,
              Age = character.Age,
              Origin = character.Origin,
              Reward = character.Reward,
              Height = character.Height,
              ImageURL = character.ImageURL,
              Rol = new GetRolesViewModel { Id = character.Rol.Id,Name = character.Rol.Name },
           
          };
    }
}
