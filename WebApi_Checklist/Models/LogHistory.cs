using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class LogHistory
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public bool? Action { get; set; }
        public string Desc { get; set; }
        public int? WorkOrderDetailsId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? InsertBy { get; set; }

        public virtual WorkOrderDetail WorkOrderDetails { get; set; }
    }
}
