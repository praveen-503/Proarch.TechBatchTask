using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Core.Domain.Common
{
    public class AuditModel : Model, IAuditModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
