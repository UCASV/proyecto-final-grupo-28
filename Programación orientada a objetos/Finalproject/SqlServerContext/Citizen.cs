using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
            ChronicDiseases = new HashSet<ChronicDisease>();
            CitizenxsideEffects = new HashSet<CitizenxsideEffect>();
        }

        public string Dui { get; set; }
        public string CitizenName { get; set; }
        public int Age { get; set; }
        public string AddressCitizen { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Identifier { get; set; }
        public int? IdInstitution { get; set; }
        public int? IdQueue { get; set; }
        public int? IdVaccination { get; set; }

        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual VacQueue IdQueueNavigation { get; set; }
        public virtual Vaccination IdVaccinationNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<ChronicDisease> ChronicDiseases { get; set; }
        public virtual ICollection<CitizenxsideEffect> CitizenxsideEffects { get; set; }
    }
}
