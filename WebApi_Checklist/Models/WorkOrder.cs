using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            WorkOrderDetails = new HashSet<WorkOrderDetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? Status { get; set; }
        public int? ApprovedBy { get; set; }
        public string Note { get; set; }

        public virtual User IdNavigation { get; set; }
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
    }
}
