using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
    public interface IPurchaseRepository:IRepository<Purchase>
    {
        bool AnyPurchaseMatchesPlateAndDateTime(string plates, string dateToCompare);
        Notification AddPurchase(Purchase purchaseToAdd);
        IEnumerable<Purchase>GetPurchasesMatchDateAndCountry(DateTime startingDate, DateTime endingDate, string plates, Country filterCountry);
    }
}
