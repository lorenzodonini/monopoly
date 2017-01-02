using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Monopoli.Model;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoli.View
{
    public partial class ControlPanel : TableLayoutPanel
    {
        private Controller.GameController _controller;
        private Partita _partita;
        private Deed[] _deedPool;
        private static DeedInfoDialog _deedInfoDialog;
        private static PropertyInfoDialog _propertyInfoDialog;

        public ControlPanel(Point location, Size size, Controller.GameController controller,
            Partita partita, Deed[] deedPool, string currency)
        {
            this._controller = controller;
            this._partita = partita;
            this._deedPool = deedPool;
            this.Size = size;
            this.Location = location;
            _deedInfoDialog = new DeedInfoDialog();
            _propertyInfoDialog = new PropertyInfoDialog(_partita.TavolaDaGioco.Caselle.OfType<Terreno>(), currency);
            _partita.PlayerChanged += this.CambioGiocatore;
            InitializeComponent();

            RegistraEventiCaselle();
            foreach (Carta carta in _partita.TavolaDaGioco.Imprevisti)
            {
                RegistraEventiCarta(carta);
            }
            foreach (Carta carta in _partita.TavolaDaGioco.Probabilità)
            {
                RegistraEventiCarta(carta);
            }
        }

        public ControlPanel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void RegistraEventiCaselle()
        {
            foreach (Monopoli.Model.Casella cell in this._partita.TavolaDaGioco.Caselle)
            {
                if (cell is Monopoli.Model.VaiInPrigione)
                {
                    ((Monopoli.Model.VaiInPrigione)cell).VaiInPrigioneEvent += SuCasellaVaiInPrigione;
                }
                else if (cell is Monopoli.Model.Terreno)
                {
                    ((Monopoli.Model.Terreno)cell).TerrenoEvent += SuCasellaTerreno;
                }
                else if (cell is Monopoli.Model.Tassa)
                {
                    ((Monopoli.Model.Tassa)cell).TassaEvent += SuCasellaTassa;
                }
                else if (cell is Monopoli.Model.Probabilità)
                {
                    ((Monopoli.Model.Probabilità)cell).ProbabilitàEvent += SuCasellaCarta;
                }
                else if (cell is Monopoli.Model.Imprevisti)
                {
                    ((Monopoli.Model.Imprevisti)cell).ImprevistiEvent += SuCasellaCarta;
                }
            }
        }

        private void RegistraEventiCarta(Carta carta)
        {
            if (carta is Carta.CartaPaga)
            {
                ((Carta.CartaPaga)carta).CartaPagaEvent += CartaPagaPescata;
            }
            else if (carta is Carta.CartaPagaPesca)
            {
                ((Carta.CartaPagaPesca)carta).CartaPagaPescaEvent += CartaPagaPescaPescata;
            }
            else if (carta is Carta.CartaPrigione)
            {
                ((Carta.CartaPrigione)carta).CartaPrigioneEvent += CartaPrigionePescata;
            }
            else if (carta is Carta.CartaRicevi)
            {
                ((Carta.CartaRicevi)carta).CartaRiceviEvent += CartaRiceviPescata;
            }
            else if (carta is Carta.CartaMuoviIndietro)
            {
                ((Carta.CartaMuoviIndietro)carta).CartaMuoviIndietroEvent += CartaMuoviIndietroPescata;
            }
            else if (carta is Carta.CartaMuoviAvanti)
            {
                ((Carta.CartaMuoviAvanti)carta).CartaMuoviAvantiEvent += CartaMuoviAvantiPescata;
            }
            else if (carta is Carta.CartaPagaPerEdifici)
            {
                ((Carta.CartaPagaPerEdifici)carta).CartaPagaPerEdificiEvent += CartaPagaPescata;
            }
        }

        #region ButtonGetters

        public Button TiraDadiButton
        {
            get { return this._tiraDadiButton; }
        }

        public Button PagaButton
        {
            get { return this._pagaButton; }
        }

        public Button PagaAffittoButton
        {
            get { return this._pagaAffittoButton; }
        }

        public Button PescaUnaCartaButton
        {
            get { return this._pescaUnaCartaButton; }
        }

        public Button PagaTassaButton
        {
            get { return this._pagaTassaButton; }
        }

        public Button TerminaTurnoButton
        {
            get { return this._terminaTurnoButton; }
        }

        public Button AcquistaTerrenoButton
        {
            get { return this._acquistaUnTerrenoButton; }
        }

        public Button VendiTerrenoButton
        {
            get { return this._vendiTerrenoButton; }
        }

        public Button PagaCauzioneButton
        {
            get { return this._pagaCauzioneButton; }
        }
        #endregion

        #region ButtonsClicked

        private void VisualizzaContrattoButtonClick(object sender, EventArgs e)
        {
            List<Deed> playerDeeds = new List<Deed>();
            List<Terreno> terreni = _partita.GetGiocatoreCorrente().Terreni;
            foreach (Terreno terreno in terreni)
            {
                playerDeeds.Add(_deedPool.Single(deed => deed.ID == terreno.ID));
            }
            _deedInfoDialog.ShowDialogWithData(_partita.Giocatori[_partita.GiocatoreCorrente].Nome, terreni, playerDeeds.ToArray());

        }

        private void VisualizzaInformazioniButtonClick(object sender, EventArgs e)
        {
            _propertyInfoDialog.ShowDialog();
        }

        private void RitiraDallaPartitaButtonClick(object sender, EventArgs e)
        {
            this._controller.RitiraDallaPartitaClicked();
        }

        private void PagaCauzioneButtonClick(object sender, EventArgs e)
        {
            this._controller.PagaCauzioneClicked();
        }

        private void CostruisciEdificioButtonClick(object sender, EventArgs e)
        {
            this._controller.CostruisciEdificioClicked();
        }

        private void TiraDadiButtonClick(object sender, EventArgs e)
        {
            this._controller.TiraDadiClicked();
        }

        private void TerminaTurnoButtonClick(object sender, EventArgs e)
        {
            this._controller.TerminaTurnoClicked();
        }

        private void PescaUnaCartaButtonClick(object sender, EventArgs e)
        {
            this._controller.PescaUnaCartaClicked();
        }

        private void AcquistaUnTerrenoButtonClick(object sender, EventArgs e)
        {
            this._controller.AcquistaUnTerrenoClicked();
        }

        private void VendiTerrenoButtonClick(object sender, EventArgs e)
        {
            this._controller.VendiTerrenoClicked();
        }

        private void DemolisciEdificioButtonClick(object sender, EventArgs e)
        {
            this._controller.DemolisciEdificioClicked();
        }

        private void PagaTassaButtonClick(object sender, EventArgs e)
        {
            this._controller.PagaTassaClicked();
        }

        private void PagaAffittoButtonClick(object sender, EventArgs e)
        {
            this._controller.PagaAffittoClicked();
        }

        private void PagaButtonClick(object sender, EventArgs e)
        {
            this._controller.PagaClicked();
        }

        #endregion

        #region Model EventHandlers
        private void SuCasellaTassa(object sender, EventArgs e)
        {
            this.PagaTassaButton.Enabled = true;
            this.TerminaTurnoButton.Enabled = false;
            this.PagaTassaButton.Focus();
            TiraDadiButton.Enabled = false;
        }

        private void SuCasellaVaiInPrigione(object sender, EventArgs e)
        {
            TiraDadiButton.Enabled = false;
            TerminaTurnoButton.Enabled = true;
            _controller.SpostaInPrigione();
        }

        private void SuCasellaTerreno(object sender, EventArgs e)
        {
            Terreno terreno = (Terreno)sender;
            if (terreno.Proprietario == null)
            {
                this.AcquistaTerrenoButton.Enabled = true;
                this.AcquistaTerrenoButton.Focus();
            }
            else if (terreno.Proprietario != _partita.GetGiocatoreCorrente())
            {
                this.TerminaTurnoButton.Enabled = false;
                this.PagaAffittoButton.Enabled = true;
                this.PagaAffittoButton.Focus();
                TiraDadiButton.Enabled = false;
            }
        }

        private void SuCasellaCarta(object sender, EventArgs e)
        {
            this.TerminaTurnoButton.Enabled = false;
            this.PescaUnaCartaButton.Enabled = true;
            this.PescaUnaCartaButton.Focus();
            TiraDadiButton.Enabled = false;
        }

        private void CambioGiocatore(object sender, EventArgs e)
        {
            if (((Giocatore)sender).InPrigione)
            {
                this.PagaCauzioneButton.Enabled = true;
            }
            this.TiraDadiButton.Enabled = true;
            TerminaTurnoButton.Enabled = false;
            AcquistaTerrenoButton.Enabled = false;
        }

        private void CartaPagaPescata(object sender, EventArgs e)
        {
            _partita.CartaCorrente = (Carta)sender;
            this.PagaButton.Enabled = true;
            this.PagaButton.Focus();
            TerminaTurnoButton.Enabled = false;
            TiraDadiButton.Enabled = false;
        }

        private void CartaRiceviPescata(object sender, EventArgs e)
        {
            this.TerminaTurnoButton.Enabled = true;
        }

        private void CartaPagaPescaPescata(object sender, EventArgs e)
        {
            _partita.CartaCorrente = (Carta)sender;
            this.PescaUnaCartaButton.Enabled = true;
            this.PagaButton.Enabled = true;
            PagaButton.Focus();
            TerminaTurnoButton.Enabled = false;
            TiraDadiButton.Enabled = false;
        }

        private void CartaMuoviAvantiPescata(object sender, EventArgs e)
        {
            _partita.CartaCorrente = (Carta)sender;
            _controller.SpostaGiocatore();
        }

        private void CartaMuoviIndietroPescata(object sender, EventArgs e)
        {
            _partita.CartaCorrente = (Carta)sender;
            _controller.SpostaGiocatore();
        }

        private void CartaPrigionePescata(object sender, EventArgs e)
        {
            _partita.CartaCorrente = (Carta)sender;
            _controller.SpostaInPrigione();
        }
        #endregion

        public void OnDispose()
        {
            _deedInfoDialog.Dispose();
            _propertyInfoDialog.Dispose();
            this.Dispose();
        }
    }
}
