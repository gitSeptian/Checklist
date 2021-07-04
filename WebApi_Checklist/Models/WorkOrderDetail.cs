using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class WorkOrderDetail
    {
        public WorkOrderDetail()
        {
            LogHistories = new HashSet<LogHistory>();
        }

        public int Id { get; set; }
        public int? WorkOrderId { get; set; }
        public int? PerangkatId { get; set; }
        public int? Action { get; set; }
        public string Note { get; set; }

        public virtual Perangkat Perangkat { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        public virtual ICollection<LogHistory> LogHistories { get; set; }
    }
}
