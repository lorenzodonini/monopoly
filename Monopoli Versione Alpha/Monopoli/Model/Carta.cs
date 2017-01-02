using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
 
    public abstract class Carta
    {
        public enum TipoCarta { IMPREVISTI = 0, PROBABILITA = 1 };
        private readonly TipoCarta _tipo;
        private readonly string _istruzioni;
        private System.Drawing.Color _colore;

        protected Carta(TipoCarta tipo, string istruzioni)
        {
            _tipo = tipo;
            _istruzioni = istruzioni;
            if (tipo == TipoCarta.PROBABILITA)
                _colore = System.Drawing.Color.FromArgb(105, 226, 167);
            else if (tipo == TipoCarta.IMPREVISTI)
                _colore = System.Drawing.Color.FromArgb(255, 175, 95);
        }

        #region Properties
        public string Istruzioni
        {
            get { return _istruzioni; }
        }

        public TipoCarta Tipo
        {
            get { return _tipo; }
        }

        public System.Drawing.Color Colore
        {
            get
            {
                return this._colore;
            }
        }
        #endregion

        public abstract void EseguiOperazione(Giocatore giocatore);

        #region Nested subclasses

        public class CartaPaga : Carta
        {
            private readonly decimal _importo;

            //public event CartaHandler CartaPagaEvent;
            public event EventHandler CartaPagaEvent;

            public CartaPaga(TipoCarta tipo, string istruzioni, decimal importo)
                :base (tipo, istruzioni)
            {
                _importo = importo;
            }

            public decimal Importo
            {
                get { return _importo; }
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaPagaEvent != null)
                {
                    CartaPagaEvent(this, EventArgs.Empty);
                }
            }
        }

        public class CartaRicevi : Carta
        {
            private readonly decimal _importo;

            public event EventHandler CartaRiceviEvent;

            public CartaRicevi(TipoCarta tipo, string istruzioni, decimal importo)
                : base(tipo, istruzioni)
            {
                _importo = importo;
            }

            public decimal Importo
            {
                get { return _importo; }
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaRiceviEvent != null)
                {
                    giocatore.IncrementaCapitale(_importo);
                    CartaRiceviEvent(this, EventArgs.Empty);
                }
            }
        }

        public class CartaPagaPerEdifici : Carta
        {
            private readonly decimal _importoCasa;
            private readonly decimal _importoAlbergo;

            public event EventHandler CartaPagaPerEdificiEvent;

            public CartaPagaPerEdifici(TipoCarta tipo, string istruzioni, decimal importoCasa, decimal importoAlbergo)
                : base(tipo, istruzioni)
            {
                _importoCasa = importoCasa;
                _importoAlbergo = importoAlbergo;
            }

            public decimal ImportoCasa
            {
                get { return _importoCasa; }
            }

            public decimal ImportoAlbergo
            {
                get { return _importoAlbergo; }
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaPagaPerEdificiEvent != null)
                {
                    CartaPagaPerEdificiEvent(this, EventArgs.Empty);
                }
            }
        }

        public class CartaPrigione : Carta
        {
            public event EventHandler CartaPrigioneEvent;

            public CartaPrigione(TipoCarta tipo, string istruzioni)
                : base(tipo, istruzioni)
            {
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaPrigioneEvent != null)
                {
                    CartaPrigioneEvent(this, EventArgs.Empty);
                }
            }
        }

        public class CartaPagaPesca : Carta
        {
            private readonly decimal _importo;

            public event EventHandler CartaPagaPescaEvent;

            public CartaPagaPesca(TipoCarta tipo, string istruzioni, decimal importo)
                : base(tipo, istruzioni)
            {
                _importo = importo;
            }

            public decimal Importo
            {
                get { return _importo; }
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaPagaPescaEvent != null)
                {
                    CartaPagaPescaEvent(this, EventArgs.Empty);
                }
            }
        }

        public class CartaMuoviAvanti : Carta
        {
            private readonly string _destinazione;

            public event EventHandler CartaMuoviAvantiEvent;

            public CartaMuoviAvanti(TipoCarta tipo, string istruzioni, string destinazione)
                : base(tipo, istruzioni)
            {
                _destinazione = destinazione;
            }

            public string Destinazione
            {
                get { return _destinazione; }
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaMuoviAvantiEvent != null)
                {
                    CartaMuoviAvantiEvent(this, EventArgs.Empty);
                }
            }
        }

        public class CartaMuoviIndietro : Carta
        {
            private readonly string _destinazione;

            public event EventHandler CartaMuoviIndietroEvent;

            public CartaMuoviIndietro(TipoCarta tipo, string istruzioni, string destinazione)
                : base(tipo, istruzioni)
            {
                _destinazione = destinazione;
            }

            public string Destinazione
            {
                get { return _destinazione; }
            }

            public override void EseguiOperazione(Giocatore giocatore)
            {
                if (CartaMuoviIndietroEvent != null)
                {
                    CartaMuoviIndietroEvent(this, EventArgs.Empty);
                }
            }
        }
        #endregion
    }
}
