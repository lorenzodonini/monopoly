using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    public interface IGameBoard
    {
        Control[] Cells { get; }
        Control[] Markers { get; }
        void AddCell(int index, Control cell);
        void RemoveCell(int index, Control cell);
        void PutMarkersOnStartCell(object [] players);
        void PutMarker(Control marker);
        void RemoveMarker(Control marker);
        void DisposeGameBoard();
        Size BoardSize { get; }
        Point BoardLocation { get; }
    }
}
