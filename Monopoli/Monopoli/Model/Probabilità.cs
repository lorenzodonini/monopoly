using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    class Probabilità : Casella
    {
        public event CasellaHandler ProbabilitàEvent;

        public Probabilità(int id, string nome) :base(id, nome)
        {

        }
        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (ProbabilitàEvent != null)
            {
                ProbabilitàEvent(this, EventArgs.Empty);
            }
        }
    }
}
