using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Nik { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
