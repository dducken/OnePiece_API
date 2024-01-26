using Core.Domain.Models;


namespace Core.Application.Services.Characters.ViewModels
{
    public class GetCharactersViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        
        public int Age { get; set; }

        public string? Origin { get; set; }

        public string? Reward { get; set; }

        public double Height { get; set; }

        public string? ImageURL { get; set; }

        public static explicit operator GetCharactersViewModel(Character character)
          => new GetCharactersViewModel
          {
              Id = character.Id,
              FullName = character.FullName,
              Age = character.Age,
              Origin = character.Origin,
              Reward = character.Reward,
              Height = character.Height,
              ImageURL = character.ImageURL,
              
          };
    }
}