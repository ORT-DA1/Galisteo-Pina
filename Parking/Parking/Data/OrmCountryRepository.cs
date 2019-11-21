using Entities;
using Entities.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace Data
{
    public class OrmCountryRepository : Repository<Country>, ICountryRepository
    {
        public ParkingContext ParkingContext
        {
            get { return Context as ParkingContext; }
        }

        public OrmCountryRepository(ParkingContext context) : base(context)
        {
        }

        public void AddCountries(IEnumerable<Country> countriesInSystem)
        {
            var countriesNotExist = countriesInSystem.Where(x => !ParkingContext.Countries.Any(c => c.Name == x.Name)).ToList();
            AddRange(countriesNotExist);
        }

        public IEnumerable<Country> GetCountries()
        {
            var countries = ParkingContext.Countries.ToList();
            return countries;
        }
    }
}
