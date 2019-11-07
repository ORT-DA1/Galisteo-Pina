using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IPurchaseRepository
    {
        Notification AddPurchase(Purchase purchase);
        bool ThereAreRecordedPurchases();
        bool AnyPurchaseMatchesPlateAndDateTime(string plateToMatch, string dateToMatch);

    }
}
