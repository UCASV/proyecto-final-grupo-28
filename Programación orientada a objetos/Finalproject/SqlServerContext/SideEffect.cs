using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class SideEffect
    {
        public SideEffect()
        {
            CitizenxsideEffects = new HashSet<CitizenxsideEffect>();
        }

        public int Id { get; set; }
        public int SeTime { get; set; }
        public string Effect { get; set; }

        public virtual ICollection<CitizenxsideEffect> CitizenxsideEffects { get; set; }
    }
}
