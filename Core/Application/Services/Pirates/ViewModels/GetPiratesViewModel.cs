using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Services.Pirates.ViewModels
{
    public class GetPiratesViewModel
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ship { get; set; }
        public string TotalReward { get; set; }
        public string ImageURL { get; set; }


        public static explicit operator GetPiratesViewModel(Pirate pirate)
          => new GetPiratesViewModel
          {
            Id = pirate.Id,
            Name = pirate.Name,
            Ship = pirate.Ship,
            TotalReward = pirate.TotalReward,
            ImageURL = pirate.ImageURL,
          };
    }
}