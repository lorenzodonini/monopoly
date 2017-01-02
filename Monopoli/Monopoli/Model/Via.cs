using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public class Via : Casella
    {

        private decimal _indennità;

        public Via(int id, string nome, decimal indennità)
            : base(id, nome)
        {
            this._indennità = indennità;
        }

        public decimal Indennità
        {
            get
            {
                return this._indennità;
            }
        }

        public override void EseguiOperazione(Giocatore giocatore)
        {
            giocatore.IncrementaCapitale(this._indennità);

        }

    }
}
