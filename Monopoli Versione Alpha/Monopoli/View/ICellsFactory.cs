using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.View
{
    interface ICellsFactory
    {
        Cell [] CreateViewCells(object[] cells, Size gamePanelSize, string currency);
    }
}
