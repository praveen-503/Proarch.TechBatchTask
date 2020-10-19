using Proarch.TechBatchTask.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.TechBatchTask.Core.Domain.Models
{
    public class ItemModel : AuditModel
    {
        public string Name { get; set; }
        public string  Descrption { get; set; }
        public double Price { get; set; }
        public int LedgerId { get; set; }
        public LedgerModel Ledger { get; set; }
    }
}
