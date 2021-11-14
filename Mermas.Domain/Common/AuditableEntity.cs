using System;

namespace Mermas.Domain.Common
{
    public abstract class AuditableEntity : Entity<int>
    {
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
