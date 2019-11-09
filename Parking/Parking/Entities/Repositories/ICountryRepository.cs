using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        IEnumerable<Country> GetCountries();
        void AddCountries(IEnumerable<Country> countries);
    }
}
