using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class ChronicDisease
    {
        public int Id { get; set; }
        public string ChronicDisease1 { get; set; }
        public string DuiCitizen { get; set; }
        public int IdDiseaseType { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual DiseaseType IdDiseaseTypeNavigation { get; set; }

        public ChronicDisease(string chronicDisease1,string duiCitizen, int idDiseaseType)
        {
            ChronicDisease1 = chronicDisease1;
            DuiCitizen = duiCitizen;
            IdDiseaseType = idDiseaseType;
        }
    }
}
