using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ParkingSystem
    {
        public List<Account> AccountList { get; set; }

        public ParkingSystem()
        {
            AccountList = new List<Account>();
        }

        public bool NoAccountInSystem()
        {
            return AccountList.Count == 0;
        }

        public bool CorrectAccountCellPhone()
        {
            return true;
        }

        public void AddAcount(Account userAccount)
        {
            AccountList.Add(userAccount);
        }
    }
}
