using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monopoli.Model;
using System.Drawing;

namespace Monopoli.View
{
    public partial class GameInfoPanel : Panel
    {
        private Partita _partita;
        private static string _giocatoreCorrente = "E' IL TURNO DI ";
        private static string _capitaleGiocatoreCorrente = "CAPITALE: ";
        private static string _posizioneGiocatoreCorrente = "POSIZIONE CORRENTE: ";
        private readonly string _currency;
        private static int _maxLogLines = 50;

        public GameInfoPanel(Point location, Size size, Partita partita, string currency)
        {
            this.Location = location;
            this.Size = size;
            _currency = " " + currency;
            _partita = partita;
            _partita.PlayerChanged += this.CambioGiocatore;
            _partita.GameTimer += this.AggiornaTimer;
            foreach (Giocatore giocatore in _partita.Giocatori)
            {
                giocatore.MoneyChanged += this.AggiornaDatiGiocatoreCorrente;
                giocatore.PlayerQuit += this.AggiornaDatiGiocatoreCorrente;
                giocatore.PositionChanged += this.AggiornaDatiGiocatoreCorrente;
            }
            InitializeComponent();

            foreach (Casella cell in _partita.TavolaDaGioco.Caselle)
            {
                if (cell is TerrenoNormale)
                    ((TerrenoNormale)cell).BuildingChanged += this.AggiornaDatiGiocatoreCorrente;
            }
            _labelGiocatore.Text = _giocatoreCorrente + _partita.GetGiocatoreCorrente().Nome;
            _labelCapitale.Text = _capitaleGiocatoreCorrente + _partita.GetGiocatoreCorrente().Capitale + _currency;
            _labelPosizione.Text = _posizioneGiocatoreCorrente + _partita.GetGiocatoreCorrente().PosizioneCorrente.Nome;
            _labelInPrigione.Text = "";
        }

        public GameInfoPanel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        #region Model EventHandlers
        private void CambioGiocatore(object sender, EventArgs e)
        {
            AggiornaDatiGiocatoreCorrente(sender, new LogEventArgs(null, 0));
        }

        private void AggiornaDatiGiocatoreCorrente(object sender, LogEventArgs e)
        {
            Giocatore giocatore = _partita.GetGiocatoreCorrente();
            _labelGiocatore.Text = _giocatoreCorrente + _partita.GetGiocatoreCorrente().Nome;
            _labelCapitale.Text = _capitaleGiocatoreCorrente + giocatore.Capitale + _currency;
            _labelPosizione.Text = _posizioneGiocatoreCorrente + giocatore.PosizioneCorrente.Nome;
            if (giocatore.InPrigione)
            {
                if (giocatore.TurniInPrigione == 1)
                {
                    _labelInPrigione.Text = "IN PRIGIONE DA " + giocatore.TurniInPrigione + " TURNO";
                }
                else
                {
                    _labelInPrigione.Text = "IN PRIGIONE DA " + giocatore.TurniInPrigione + " TURNI";
                }
            }
            else
            {
                _labelInPrigione.Text = "";
            }
            if (e != null && e.LogMessage != null)
            {
                AggiornaLog(e);
            }
        }

        private void AggiornaLog(LogEventArgs e)
        {
            if (_logBox.Lines.Length > _maxLogLines)
            {
                _logBox.Clear();
            }
            if (e.Value >= 0)
            {
                this._logBox.Text += e.LogMessage + e.Value + _currency + Environment.NewLine;
            }
            else
            {
                this._logBox.Text += e.LogMessage + Environment.NewLine;
            }
            _logBox.SelectionStart = _logBox.Text.Length;
            _logBox.ScrollToCaret();
            _logBox.Refresh();
        }

        private void AggiornaTimer(object sender, EventArgs e)
        {
            TimeSpan time = _partita.TempoDaGiocare;
            if (time.Hours < 10)
            {
                _labelTempo.Text = "Tempo di Gioco rimanente: 0" + time.Hours + ":";
            }
            else
            {
                _labelTempo.Text = "Tempo di Gioco rimanente: " + time.Hours + ":";
            }
            if (time.Minutes < 10)
            {
                _labelTempo.Text += "0" + time.Minutes;
            }
            else
            {
                _labelTempo.Text += time.Minutes;
            }
        }
        #endregion
    }
}
