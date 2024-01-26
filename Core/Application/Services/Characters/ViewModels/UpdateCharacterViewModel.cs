using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.Services.Characters.ViewModels
{
    public class UpdateCharacterViewModel
    {
  
        public string FullName { get; set; }
        
        public int Age { get; set; }

        public string? Origin { get; set; }

        public string? Reward { get; set; }

        public double Height { get; set; }

        public string? ImageURL { get; set; }

        public int PirateId { get; set; }

        public int RolId { get; set; }



    }
}