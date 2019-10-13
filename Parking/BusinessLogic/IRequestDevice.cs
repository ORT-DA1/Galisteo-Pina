using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface IRequestDevice
    {
        string InputPlate();
        string InputMinutes();
        DateTime InputSartingHour();
    }
}
