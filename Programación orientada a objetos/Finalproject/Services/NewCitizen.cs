using Finalproject.Repository;
using Finalproject.SqlServerContext;

namespace Finalproject.Services
{
    public class NewCitizen : Repository<Citizen>
    {
        private VaccinationDBContext _context1;

        public NewCitizen()
        {
            _context1 = new VaccinationDBContext();
        }

        public void create(Citizen newCitizen)
        {
            _context1.Add(newCitizen);
            _context1.SaveChanges();
        }
    }
}