using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class CitizenxsideEffect
    {
        public int IdSideEffect { get; set; }
        public string DuiCitizen { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual SideEffect IdSideEffectNavigation { get; set; }
    }
}
