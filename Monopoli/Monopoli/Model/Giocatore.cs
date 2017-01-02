using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public delegate void PositionChangedHandler(object sender, LogEventArgs e);
    public delegate void MoneyChangedHandler(object sender, LogEventArgs e);
    public delegate void PlayerQuitHandler(object sender, LogEventArgs e);

    public class Giocatore
    {
        public event PositionChangedHandler PositionChanged;
        public event MoneyChangedHandler MoneyChanged;
        public event PlayerQuitHandler PlayerQuit;

        private readonly string _nome;
        private decimal _capitale;
        private readonly string _segnalino;
        private bool _inPrigione;
        private bool _attivo;
        private Casella _posizioneCorrente;
        private List<Terreno> _terreni;
        private Dictionary<string, int> _terreniPerGruppo;
        private int _turniInPrigione;

        public Giocatore(string nome, decimal capitale, string segnalino, Casella posizioneIniziale)
        {
            this._nome = nome;
            this._capitale = capitale;
            this._segnalino = segnalino;
            this._inPrigione = false;
            this._attivo = true;
            this._posizioneCorrente = posizioneIniziale;
            this._terreni = new List<Terreno>();
            this._terreniPerGruppo = new Dictionary<string, int>();
            _turniInPrigione = 0;
        }

        public string Nome
        {
            get
            {
                return this._nome;
            }
        }

        public decimal Capitale
        {
            get
            {
                return this._capitale;
            }
        }

        public string Segnalino
        {
            get
            {
                return this._segnalino;
            }
        }

        public bool InPrigione
        {
            get
            {
                return this._inPrigione;
            }
            set
            {
                this._inPrigione = value;
            }
        }

        public bool Attivo
        {
            get
            {
                return this._attivo;
            }
            set
            {
                this._attivo = value;
                foreach (Terreno terreno in _terreni)
                {
                    if(terreno is TerrenoNormale)
                    {
                        while (((TerrenoNormale)terreno).NumeroEdifici > 0)
                        {
                            ((TerrenoNormale)terreno).DemolisciEdificio();
                        }
                    }
                    terreno.Proprietario = null;
                }
                _terreni.Clear();
                _capitale = 0;
                OnPlayerQuit(this, new LogEventArgs(Nome + " è diventato inattivo", -1));
            }
        }

        public Casella PosizioneCorrente
        {
            get
            {  
                return this._posizioneCorrente; 
            }
            set
            {  
                this._posizioneCorrente=value;
                OnPositionChanged(this, new LogEventArgs(Nome + " si è spostato su " + PosizioneCorrente.Nome, -1));
            }
        }

        public List<Terreno> Terreni
        {
            get
            {
                return this._terreni;
            }
        }

        public int TurniInPrigione
        {
            get
            {
                return _turniInPrigione;
            }
            set
            {
                _turniInPrigione = value;
            }
        }

        public virtual void IncrementaCapitale(decimal importo)
        {
            if (importo < 0)
            {
                throw new ArgumentException("Money < 0");
            }
            this._capitale += importo;
            OnMoneyChanged(this, new LogEventArgs(Nome + " ha incassato ", importo));
        }

        public virtual void DecrementaCapitale(decimal importo)
        {
            if (importo < 0)
            {
                throw new ArgumentException("Money > 0");
            }
            if (_capitale - importo < 0)
            {
                throw new InvalidOperationException("Not enough money");
            }
            this._capitale -= importo;
            OnMoneyChanged(this, new LogEventArgs(Nome + " ha pagato ", importo));
        }

        public Dictionary<string, int> TerreniPerGruppo
        {
            get { return _terreniPerGruppo; }
        }

        public virtual void AcquistaTerreno(Terreno terreno)
        {
            if (terreno.Proprietario != null)
            {
                throw new InvalidOperationException("Property already bought");
            }
            _terreni.Add(terreno);
            if (_terreniPerGruppo.ContainsKey(terreno.NomeGruppo))
            {
                _terreniPerGruppo[terreno.NomeGruppo]++;
            }
            else
            {
                _terreniPerGruppo.Add(terreno.NomeGruppo, 1);
            }
            terreno.Proprietario = this;
            DecrementaCapitale(terreno.Valore);
        }

        public virtual void VendiTerreno(Terreno terreno)
        {
            _terreni.Remove(terreno);
            if (_terreniPerGruppo[terreno.NomeGruppo] > 1)
            {
                _terreniPerGruppo[terreno.NomeGruppo]--;
            }
            else
            {
                _terreniPerGruppo.Remove(terreno.NomeGruppo);
            }
            terreno.Proprietario = null;
            IncrementaCapitale(terreno.ValoreDiVendita);
        }

        public virtual bool HaTerreniEdificabili()
        {
            foreach (Terreno terreno in _terreni)
            {
                if (terreno is TerrenoNormale)
                {
                    TerrenoNormale tn = (TerrenoNormale)terreno;
                    if (tn.IsEdificabile(TerreniPerGruppo[tn.NomeGruppo]))
                        return true;
                }
            }
            return false;
        }

        private void OnPositionChanged(object sender, LogEventArgs e)
        {
            if (PositionChanged != null)
            {
                PositionChanged(sender, e);
            }
        }

        private void OnMoneyChanged(object sender, LogEventArgs e)
        {
            if (MoneyChanged != null)
            {
                MoneyChanged(sender, e);
            }
        }

        private void OnPlayerQuit(object sender, LogEventArgs e)
        {
            if (PlayerQuit != null)
            {
                PlayerQuit(sender, e);
            }
        }

        public void Fallisci()
        {
            this.Attivo= false;
            foreach (Terreno terreno in this._terreni)
            {
                terreno.Proprietario = null;
                if (terreno is TerrenoNormale)
                {
                    ((TerrenoNormale)terreno).ResetEdifici();
                }
            }
            this._capitale = 0;
        }



    }
}
