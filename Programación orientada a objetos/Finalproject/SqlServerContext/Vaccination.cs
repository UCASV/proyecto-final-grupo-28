using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class Vaccination
    {
        public Vaccination()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public DateTime? VaccinationDate { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
