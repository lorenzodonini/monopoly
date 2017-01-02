using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.View
{
    interface ICellsFactory
    {
        Cell [] CreateViewCells(object[] cells, int gamePanelLength, string currency);
    }
}
