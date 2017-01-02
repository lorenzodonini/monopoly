using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public class Prigione : Casella
    {
        private decimal _cauzione;

        public Prigione(int id, string nome, decimal cauzione)
            : base(id, nome)
        {
            this._cauzione = cauzione;
        }

        public decimal Cauzione
        {
            get
            {
                return this._cauzione;
            }
        }

        public override void EseguiOperazione(Giocatore giocatore)
        {
        }
    }
}
