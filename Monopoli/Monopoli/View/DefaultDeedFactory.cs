using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.View
{
    class DefaultDeedFactory : IDeedFactory
    {
        string _currency;

        public DefaultDeedFactory(string currency)
        {
            _currency = currency;
        }

        public virtual Deed [] CreateDeeds(object[] deeds)
        {
            List<Deed> result = new List<Deed>();
            foreach (Controller.DefaultConfigLoader.CellValue cell in deeds)
            {
                if(cell.Model.Contains("Terreno"))
                {
                    result.Add(CreateDeed(cell));
                }
            }
            return result.ToArray();
        }

        protected virtual Deed CreateDeed(Controller.DefaultConfigLoader.CellValue cell)
        {
            Deed result = null;
            List<object> args = cell.ToDeedArguments();
            args.Add(_currency);
            Type type = Type.GetType("Monopoli.View."+cell.Type+"Deed");
            result = (Deed)Activator.CreateInstance(type, args.ToArray());
            return result;
        }
    }
}
