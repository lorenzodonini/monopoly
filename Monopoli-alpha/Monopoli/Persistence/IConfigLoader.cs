using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Controller
{
    interface IConfigLoader
    {
        void Load();
        IEnumerable<object> GetCells();
        IEnumerable<object> GetCards();
        object GetPlayBoard();
        int GetPlayerMinNum();
        int GetPlayerMaxNum();
        int GetNumCells();
        string GetCurrencySymbol();
        Dictionary<int, decimal> GetInitialMoneyValues();
        Dictionary<int, int> GetinitialDeeds();
        Dictionary<string, System.Drawing.Image> GetMarkers();
    }
}
