using System.ComponentModel.DataAnnotations;

namespace Core.Application.Services.Pirates.ViewModels
{
    public class CreatePirateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Ship { get; set; }

        [Required]
        [MaxLength(300)]
        public string? TotalReward { get; set; }

        [Required]
        public string? ImageURL { get; set; }

 
    }
}