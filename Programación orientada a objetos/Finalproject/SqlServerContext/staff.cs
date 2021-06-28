using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class staff
    {
        public staff()
        {
            Appointments = new HashSet<Appointment>();
            LoginInfos = new HashSet<LoginInfo>();
        }

        public string Id { get; set; }
        public string NameStaff { get; set; }
        public string Email { get; set; }
        public string PasswordStaff { get; set; }
        public string UserStaff { get; set; }
        public string AddressStaff { get; set; }
        public int IdType { get; set; }

        public virtual StaffType IdTypeNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<LoginInfo> LoginInfos { get; set; }
    }
}
