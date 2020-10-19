using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Core.Domain.Common
{
    public interface ICreated
    {
        DateTime CreatedAt { get; set; }
    }
    public interface IModified
    {
        DateTime? LastModifiedAt { get; set; }
    }
    public interface ISoftDelete
    {
        bool IsDelete { get; set; }
    }
    public interface IAuditModel : ICreated, IModified, ISoftDelete
    {
    }
}
