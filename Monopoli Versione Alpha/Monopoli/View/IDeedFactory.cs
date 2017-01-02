using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.View
{
    interface IDeedFactory
    {
        Deed [] CreateDeeds(object[] properties);
    }
}
