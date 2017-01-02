using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public delegate void PlayerChangedHandler(object sender, EventArgs e); 
    public delegate void GameEndedHandler(object sender, EventArgs e);
    public delegate void GameTimerHandler(object sender, EventArgs e);

    public class Partita
    {
        public event PlayerChangedHandler PlayerChanged;
        public event GameEndedHandler GameEnded;
        public event GameTimerHandler GameTimer;

        private readonly Giocatore[] _giocatori;
        private readonly TavolaDaGioco _tavolaDaGioco;
        private int _giocatoreCorrente;
        private Random _random;
        private int _risultatoDado1;
        private int _risultatoDado2;
        private int _nDoppi;
        private Carta _cartaCorrente = null;
        private TimeSpan _tempoDaGiocare;
        private System.Windows.Forms.Timer _timerPartita;


        public Partita(Giocatore[] giocatori, TavolaDaGioco tavolaDaGioco, TimeSpan tempoDaGiocare)
        {
            _giocatori = giocatori;
            ShuffleUtility.Shuffle(_giocatori, _giocatori.Length);
            _tavolaDaGioco = tavolaDaGioco;
            _nDoppi = 0;
            _risultatoDado1 = 0;  //quando i dadi non sono lanciati i loro valori sono 0
            _risultatoDado2 = 0;
            _giocatoreCorrente = 0; //alla creazione della partita inizia a giocare il giocatore in posizione 0 nell'array
            _timerPartita = new System.Windows.Forms.Timer();
            _timerPartita.Enabled = false;
            _tempoDaGiocare = tempoDaGiocare;
            _random = new Random();
        }

        public Giocatore[] Giocatori
        {
            get { return _giocatori; }
        }

        public TavolaDaGioco TavolaDaGioco
        {
            get { return _tavolaDaGioco; }
        }

        public int RisultatoDado1
        {
            get { return _risultatoDado1; }
            set { this._risultatoDado1 = value; }
        }

        public int RisultatoDado2
        {
            get { return _risultatoDado2; }
            set { this._risultatoDado2 = value; }
        }


        public int NDoppi
        {
            get { return _nDoppi; }
            set { this._nDoppi = value; }
        }


        public int GiocatoreCorrente
        {
            get { return _giocatoreCorrente; }
            set { this._giocatoreCorrente = value; }
        }

        public Carta CartaCorrente
        {
            get
            {
                return _cartaCorrente;
            }
            set
            {
                _cartaCorrente = value;
            }
        }

        public bool TiraDadi()
        {
            _risultatoDado1 = _random.Next(6) + 1;
            _risultatoDado2 = _random.Next(6) + 1;

            if (_risultatoDado1 == _risultatoDado2)
            {
                _nDoppi++;
                return true;
            }
            return false;
        }


        public void PassaTurnoAProssimoGiocatoreAttivo()
        {
            int attivi = 0;
            foreach (Giocatore giocatore in _giocatori)
            {
                if (giocatore.Attivo)
                {
                    attivi++;
                }
            }
            if (attivi <= 1)
            {
                if (GameEnded != null)
                {
                    GameEnded(this, EventArgs.Empty);
                }
            }
            GiocatoreCorrente++;
            if (GiocatoreCorrente >= Giocatori.Length)
            {
                GiocatoreCorrente = 0;
            }
            if (Giocatori[GiocatoreCorrente].Attivo == false)
            {
                PassaTurnoAProssimoGiocatoreAttivo();
            }
            else
            {
                _nDoppi = 0;
            }
            if (this.PlayerChanged != null)
            {
                PlayerChanged(GetGiocatoreCorrente(), EventArgs.Empty);
            }
        }

        public Giocatore GetGiocatoreCorrente()
        {
            return Giocatori[GiocatoreCorrente];
        }

        public TimeSpan TempoDaGiocare
        {
            get { return _tempoDaGiocare; }
        }

        public void OnTimerChanged(object sender, EventArgs e)
        {
            if (_timerPartita.Enabled)
            {
                _tempoDaGiocare = _tempoDaGiocare.Subtract(new TimeSpan(0, 0, 60));
            }
            if (this.GameTimer != null)
            {
                GameTimer(this, EventArgs.Empty);
                if (_tempoDaGiocare.TotalMinutes == 0)
                {
                    GameEnded(this, EventArgs.Empty);
                }
            }
        }

        public void AvviaTimer()
        {
            if (_tempoDaGiocare.TotalMinutes > 0)
            {
                _timerPartita.Tick += OnTimerChanged;
                _timerPartita.Interval = 60 * 1000;
                OnTimerChanged(this, EventArgs.Empty);
                _timerPartita.Start();
            }
        }

        public void ArrestaTimer()
        {
            if (_timerPartita != null && _timerPartita.Enabled)
            {
                _timerPartita.Stop();
            }
        }

        public void AggiornaAffittoTerreniGiocatore()
        {
            foreach (Terreno terreno in Giocatori[_giocatoreCorrente].Terreni)
            {
                terreno.AggiornaAffitto(TavolaDaGioco.Gruppi[terreno.NomeGruppo]);
            }
        }

        public List<Statistica> CalcolaStatistiche()
        {
            List<Statistica> statistiche = new List<Statistica>();
            foreach (Giocatore giocatore in _giocatori)
            {
                Statistica statistica;
                statistica._capitale = giocatore.Capitale;
                statistica._nomeGiocatore = giocatore.Nome;
                statistica._numeroTerreniPosseduti = giocatore.Terreni.Count;
                statistica._valoreComplessivoTerreni = 0;
                foreach (Terreno terreno in giocatore.Terreni)
                {
                    statistica._valoreComplessivoTerreni += terreno.Valore;
                }
                statistica._numeroCasePossedute = 0;
                statistica._numeroAlberghiPosseduti = 0;
                statistica._valoreComplessivoEdifici = 0;
                IEnumerable<TerrenoNormale> terreniNormali = giocatore.Terreni.OfType<TerrenoNormale>();
                foreach (TerrenoNormale terreno in terreniNormali)
                {
                    if (terreno.NumeroEdifici == terreno.MaxEdifici)
                    {
                        statistica._numeroAlberghiPosseduti++;
                    }
                    else
                    {
                        statistica._numeroCasePossedute += terreno.NumeroEdifici;
                    }
                    statistica._valoreComplessivoEdifici += (terreno.NumeroEdifici * terreno.PrezzoCostruzioneEdificio);
                }
                statistica._valoreTotale = statistica._capitale + statistica._valoreComplessivoEdifici + statistica._valoreComplessivoTerreni;
                statistiche.Add(statistica);
            }
            return statistiche.OrderByDescending(statistica => statistica._valoreTotale).ToList();
        }

        public struct Statistica
        {
            public string _nomeGiocatore;
            public decimal _capitale;
            public int _numeroTerreniPosseduti;
            public decimal _valoreComplessivoTerreni;
            public int _numeroCasePossedute;
            public int _numeroAlberghiPosseduti;
            public decimal _valoreComplessivoEdifici;
            public decimal _valoreTotale;
        }
    }
}
