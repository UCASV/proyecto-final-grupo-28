using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime FirstDoseDate { get; set; }
        public DateTime? SecondDoseTime { get; set; }
        public string IdStaff { get; set; }
        public string DuiCitizen { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual staff IdStaffNavigation { get; set; }
    }
}
