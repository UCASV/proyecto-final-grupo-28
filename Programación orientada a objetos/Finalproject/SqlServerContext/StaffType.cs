using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class StaffType
    {
        public StaffType()
        {
            staff = new HashSet<staff>();
        }

        public int Id { get; set; }
        public string StaffType1 { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
