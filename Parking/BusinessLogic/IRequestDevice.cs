using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IRequestDevice
    {
        string Plates { get; set; }
        string Minutes { get; set; }
  
        DateTime StartingHour { get; set; }

        DateTime EndingHour { get; set; }

        DateTime LowerHourLimit { get; set; }

        DateTime UpperHourLimit { get; set; }
    }
}
