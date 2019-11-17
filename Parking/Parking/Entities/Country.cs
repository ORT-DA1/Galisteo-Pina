using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Country
    {
        public enum CountriesInSystem
        {
            URUGUAY,
            ARGENTINA
        }

        [Key]
        public string Name { get; set; }

        public int CostPerMinut { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }
        public static List<Country> GetCountriesInSystem()
        {
            List<Country> countries = new List<Country>();
            foreach (var e in Enum.GetValues(typeof(Country.CountriesInSystem)))
            {
                countries.Add(new Country(e.ToString()));
            }
            return countries;
        }

}
    
}
