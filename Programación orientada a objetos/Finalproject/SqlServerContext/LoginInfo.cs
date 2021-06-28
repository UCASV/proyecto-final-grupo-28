using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class LoginInfo
    {
        public int Id { get; set; }
        public int IdCabin { get; set; }
        public string IdStaff { get; set; }
        public DateTime LoginDate { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual staff IdStaffNavigation { get; set; }
    }
}
