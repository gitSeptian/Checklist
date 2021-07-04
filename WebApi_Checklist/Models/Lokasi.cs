using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class Lokasi
    {
        public int Id { get; set; }
        public string NamaLokasi { get; set; }
        public string Suhu { get; set; }
        public bool? IsSensorWork { get; set; }
        public string Kelambapan { get; set; }

        public virtual Rak Rak { get; set; }
    }
}
