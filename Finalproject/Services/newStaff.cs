using Finalproject.Repository;
using Finalproject.SqlServerContext;
using System;
using System.Collections.Generic;
using System.Linq;
using Finalproject.Services;

using System.Text;
using System.Threading.Tasks;

namespace Finalproject.Services
{
    public class newStaff : Repository<staff>
    {

        private VaccinationDBContext _context;

        public newStaff()
        {
            _context = new VaccinationDBContext();
        }


        public void create(staff newStaff)
        {
            _context.Add(newStaff);
            _context.SaveChanges();
        }


    }
}
