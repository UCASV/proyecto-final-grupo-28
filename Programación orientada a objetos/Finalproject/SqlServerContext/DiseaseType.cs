using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class DiseaseType
    {
        public DiseaseType()
        {
            ChronicDiseases = new HashSet<ChronicDisease>();
        }

        public int Id { get; set; }
        public string DiseaseType1 { get; set; }

        public virtual ICollection<ChronicDisease> ChronicDiseases { get; set; }
    }
}
