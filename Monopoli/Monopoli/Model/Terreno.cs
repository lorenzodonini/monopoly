using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public abstract class Terreno : Casella
    {
        public event CasellaHandler TerrenoEvent;

        protected static int _indiceAffittoBase = 0;
        private readonly decimal [] _valoriDiAffitto;
        private readonly decimal _valore;
        private readonly decimal _valoreDiVendita;
        private decimal _affitto;
        private Giocatore _proprietario;
        private readonly string _nomeGruppo;

        protected Terreno(int id, string nome, decimal valore, decimal valoreDiVendita, decimal [] valoriDiAffitto, string nomeGruppo) : base(id, nome)
        {
            this._valore = valore;
            this._valoreDiVendita = valoreDiVendita;
            this._valoriDiAffitto = valoriDiAffitto;
            this._affitto = _valoriDiAffitto[_indiceAffittoBase];
            this._proprietario = null;
            this._nomeGruppo = nomeGruppo;
        }

        public decimal[] ValoriDiAffitto
        {
            get { return _valoriDiAffitto; }
        }

        public decimal Valore
        {
            get
            {
                return this._valore;
            }
        }

        public decimal ValoreDiVendita
        {
            get
            {
                return this._valoreDiVendita;
            }
        }

        public decimal Affitto
        {
            get
            {
                return this._affitto;
            }
            set
            {
                _affitto = value;
            }
        }

        public Giocatore Proprietario
        {
            get
            {
                return this._proprietario;
            }

            set
            {
                this._proprietario = value;
            }
        }

        public string NomeGruppo
        {
            get { return _nomeGruppo; }
        }

        public abstract bool IsVendibile(int terreniDelGruppo, List<Terreno> terreniDelGruppoPosseduti);

        public abstract void AggiornaAffitto(int terreniDelGruppo); //terreniDelGruppo è il numero totale di terreni del gruppo corrente

        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (TerrenoEvent != null)
            {
                TerrenoEvent(this, EventArgs.Empty);
            }
        }
    }
}
