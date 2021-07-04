using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class Perangkat
    {
        public Perangkat()
        {
            WorkOrderDetails = new HashSet<WorkOrderDetail>();
        }

        public int Id { get; set; }
        public string NamaPerangkat { get; set; }
        public string Type { get; set; }
        public int? RakId { get; set; }
        public bool? StatusPerangkat { get; set; }
        public string Notes { get; set; }
        public string Merk { get; set; }
        public int? Unit { get; set; }
        public int? InsertBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Rak IdNavigation { get; set; }
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
    }
}
