using System;
using System.Collections.Generic;

#nullable disable

namespace Finalproject.SqlServerContext
{
    public partial class Cabin
    {
        public Cabin()
        {
            LoginInfos = new HashSet<LoginInfo>();
        }

        public int Id { get; set; }
        public string AddressCabin { get; set; }
        public string Phone { get; set; }
        public string InCharge { get; set; }
        public string Email { get; set; }

        public virtual ICollection<LoginInfo> LoginInfos { get; set; }
    }
}
