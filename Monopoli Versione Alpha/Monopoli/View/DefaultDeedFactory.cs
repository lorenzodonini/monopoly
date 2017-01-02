using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoli.Model;
using System.Reflection;

namespace Monopoli.View
{
    class DefaultDeedFactory : IDeedFactory
    {
        string _currency;

        public DefaultDeedFactory(string currency)
        {
            _currency = currency;
        }

        #region IDeedFactory
        public virtual Deed [] CreateDeeds(object[] properties)
        {
            List<Deed> result = new List<Deed>();
            foreach (Casella cell in properties)
            {
                if(cell is Terreno)
                {
                    result.Add(CreateDeed(cell));
                }
            }
            return result.ToArray();
        }
        #endregion

        protected virtual Deed CreateDeed(Casella cell)
        {
            Deed result = null;
            List<object> args = (List<object>)((Terreno)cell).GetContratto();
            args.Add(_currency);
            Type type = Type.GetType("Monopoli.View."+cell.TipoCella+"Deed");
            result = (Deed)Activator.CreateInstance(type, args.ToArray());
            return result;
        }
    }
}
