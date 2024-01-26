using Core.Application.Services.Characters.ViewModels;
using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    /// <summary>
    /// Pirate crew name
    /// </summary>
    public class Pirate : BaseModel
    {
        public string Name { get; set; }
        public string Ship { get; set; }
        public string TotalReward { get; set; }
        public string ImageURL { get; set; }
        public List<Character> Members { get; set; }
     
    }
}
