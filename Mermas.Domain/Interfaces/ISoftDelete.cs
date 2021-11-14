using System;

namespace Mermas.Domain.Interfaces
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; }
    }
}
