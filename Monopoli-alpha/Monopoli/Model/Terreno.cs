using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public abstract class Terreno : Casella
    {
        public event EventHandler TerrenoEvent;

        protected static int _indiceAffittoBase = 0;
        private readonly decimal [] _valoriDiAffitto;
        private readonly decimal _valore;
        private readonly decimal _valoreDiVendita;
        private decimal _affitto;
        private Giocatore _proprietario;
        private readonly string _nomeGruppo;

        protected Terreno(int id, string nome, string tipoCella, decimal valore, decimal valoreDiVendita, decimal [] valoriDiAffitto, 
            string nomeGruppo) : base(id, nome, tipoCella)
        {
            this._valore = valore;
            this._valoreDiVendita = valoreDiVendita;
            this._valoriDiAffitto = valoriDiAffitto;
            this._affitto = _valoriDiAffitto[_indiceAffittoBase];
            this._proprietario = null;
            this._nomeGruppo = nomeGruppo;
        }

        #region Properties
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

        public decimal[] ValoriDiAffitto
        {
            get { return _valoriDiAffitto; }
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
        #endregion

        public abstract IEnumerable<object> GetContratto();

        public abstract bool IsVendibile(int terreniDelGruppo, List<Terreno> terreniDelGruppoPosseduti);

        public abstract void AggiornaAffitto(int terreniDelGruppo); //terreniDelGruppo è il numero totale di terreni del gruppo corrente

        #region Casella
        public override void EseguiOperazione(Giocatore giocatore)
        {
            if (TerrenoEvent != null)
            {
                TerrenoEvent(this, EventArgs.Empty);
            }
        }

        public abstract override IEnumerable<object> GetParametriCella();
        #endregion
    }
}
