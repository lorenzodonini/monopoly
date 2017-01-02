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
        protected string _name;
        protected int _id;
        protected decimal _value;
        protected decimal _sellValue;
        protected string _currencySymbol;
        protected decimal[] _rentValues;

        protected Deed(int id, string name, decimal value, decimal sellValue, decimal[] rentValues, string currency)
        {
            _id = id;
            _name = name;
            _value = value;
            _sellValue = sellValue;
            _rentValues = rentValues;
            _currencySymbol = currency;
            this.Size = new System.Drawing.Size(250, 300);
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        public int ID
        {
            get { return _id; }
        }
    }
}
