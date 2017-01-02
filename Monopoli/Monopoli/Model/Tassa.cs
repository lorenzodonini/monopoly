using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    class Tassa : Casella
    {
        private decimal _importo;

        public event CasellaHandler TassaEvent;

        public decimal Importo
        {
            get
            {
                return this._importo;
            }
        }

        public Tassa(int id, string nome, decimal importo) : base(id, nome)
        {
            this._importo = importo;
        }

        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (TassaEvent != null)
            {
                TassaEvent(this, EventArgs.Empty);
            }
        }


    }
}
