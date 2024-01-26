using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    /// <summary>
    /// Fruit that grants powers to the consumer
    /// </summary>
    public class Fruit : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }

    }
}
