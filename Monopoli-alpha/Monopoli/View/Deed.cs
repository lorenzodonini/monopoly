using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    public abstract class Deed : Panel
    {
        protected static System.Drawing.Font _valueFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, 
            System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private string _deedName;
        private readonly int _id;
        private decimal _value;
        private decimal _sellValue;
        protected readonly string _currencySymbol;
        private decimal[] _rentValues;
        private string _group;

        protected Deed(int id, string name, decimal value, decimal sellValue, decimal[] rentValues, string currency, string group)
        {
            _id = id;
            _deedName = name;
            _value = value;
            _sellValue = sellValue;
            _rentValues = rentValues;
            _currencySymbol = currency;
            _group = group;
            this.Size = new System.Drawing.Size(250, 300);
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        #region Properties
        public int ID
        {
            get { return _id; }
        }

        protected string DeedName
        {
            get { return _deedName; }
        }

        protected decimal Value
        {
            get { return _value; }
        }

        protected decimal SellValue
        {
            get { return _sellValue; }
        }

        protected decimal[] RentValues
        {
            get { return _rentValues; }
        }

        protected string Group
        {
            get { return _group; }
        }
        #endregion
    }
}
