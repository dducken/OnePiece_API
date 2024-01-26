using Core.Application.Services.Characters.ViewModels;
using Core.Application.Services.Roles.ViewModels;
using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Services.Pirates.ViewModels
{
    public class GetPirateDetailsViewModel
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ship { get; set; }
        public string TotalReward { get; set; }
        public string ImageURL { get; set; }
        public List<GetCharacterMinDetailsViewModel> Members { get; set; }


        public static explicit operator GetPirateDetailsViewModel(Pirate pirate)
          => new GetPirateDetailsViewModel
          {
            Id = pirate.Id,
            Name = pirate.Name,
            Ship = pirate.Ship,
            TotalReward = pirate.TotalReward,
            ImageURL = pirate.ImageURL,
            Members = pirate.Members.Select(member => new GetCharacterMinDetailsViewModel
            {
                Id = member.Id, 
                FullName = member.FullName,
                ImageURL= member.ImageURL,

            }).ToList()

          };
    }
}