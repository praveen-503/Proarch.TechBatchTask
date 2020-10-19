using Proarch.TechBatchTask.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Core.Domain.Models
{
    public class LedgerModel : AuditModel 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ItemId { get; set; }
        public ICollection<ItemModel> Items{ get; set; }
    }
}
