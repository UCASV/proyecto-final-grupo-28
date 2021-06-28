using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class VacQueue
    {
        public VacQueue()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public DateTime VacQueue1 { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
