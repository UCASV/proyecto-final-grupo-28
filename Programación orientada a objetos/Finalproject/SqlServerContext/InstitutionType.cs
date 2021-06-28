using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class InstitutionType
    {
        public InstitutionType()
        {
            Institutions = new HashSet<Institution>();
        }

        public int Id { get; set; }
        public string InstType { get; set; }

        public virtual ICollection<Institution> Institutions { get; set; }
    }
}
