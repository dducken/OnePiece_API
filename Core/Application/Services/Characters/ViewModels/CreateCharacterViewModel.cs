using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.Services.Characters.ViewModels
{
    public class CreateCharacterViewModel
    {
        [Required]
        public string FullName { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Origin { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Reward { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public string? ImageURL { get; set; }

        [Required]
        public int PirateId { get; set; }

        [Required]
        public int RolId { get; set; }



    }
}