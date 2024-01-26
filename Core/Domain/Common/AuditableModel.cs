using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public abstract class AuditableModel
    {
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
