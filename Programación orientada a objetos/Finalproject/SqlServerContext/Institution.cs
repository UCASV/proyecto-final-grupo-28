using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class Institution
    {
        public Institution()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string Institution1 { get; set; }
        public int IdType { get; set; }

        public virtual InstitutionType IdTypeNavigation { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
