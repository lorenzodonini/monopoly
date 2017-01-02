using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    class VaiInPrigione: Casella
    {
        public event CasellaHandler VaiInPrigioneEvent;

        public VaiInPrigione(int id, string nome) : base(id, nome)
        {
            
        }

        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (VaiInPrigioneEvent != null)
            {
                VaiInPrigioneEvent(this, EventArgs.Empty);
            }
        }
    }
}
