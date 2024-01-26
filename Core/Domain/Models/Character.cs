using Core.Domain.Common;

namespace Core.Domain.Models
{
    /// <summary>
    /// Character of the anime 'One Piece'
    /// </summary>
    public class Character : BaseModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string? Origin { get; set; }
        public string? Reward { get; set; }
        public double Height { get; set; }
        public string? ImageURL { get; set; }
        public int PirateId { get; set; }
        public Pirate Pirate { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }

    }
}
