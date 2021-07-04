using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class Rak
    {
        public int Id { get; set; }
        public string NoRak { get; set; }
        public int? LokasiId { get; set; }

        public virtual Lokasi IdNavigation { get; set; }
        public virtual Perangkat Perangkat { get; set; }
    }
}
