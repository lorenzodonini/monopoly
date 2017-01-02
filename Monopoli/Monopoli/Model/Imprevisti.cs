using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    class Imprevisti : Casella
    {
        public event CasellaHandler ImprevistiEvent;


        public Imprevisti(int id, string nome) :base(id, nome)
        {

        }
        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (ImprevistiEvent != null)
            {
                ImprevistiEvent(this, EventArgs.Empty);
            }
        }
    }
}
