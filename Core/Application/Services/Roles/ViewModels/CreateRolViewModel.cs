using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.Services.Roles.ViewModels
{
    public class CreateRolViewModel
    {
        [Required]
        public string Name { get; set; }
        
    }
}