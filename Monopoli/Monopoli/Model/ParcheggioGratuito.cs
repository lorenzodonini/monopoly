using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    class ParcheggioGratuito : Casella
    {
        public ParcheggioGratuito(int id, string nome) : base(id, nome)
        {
            
        }

        public override void EseguiOperazione(Giocatore giocatore)
        {
        }
    }
}
