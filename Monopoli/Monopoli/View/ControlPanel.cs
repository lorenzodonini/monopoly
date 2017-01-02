using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Monopoli.Model;

namespace Monopoli.View
{
    public class ControlPanel : Panel
    {
        #region variables
        private Controller.GameController _controller;
        private Partita _partita;
        private Deed[] _deedPool;
        private static DeedInfoDialog _deedInfoDialog;
        private static PropertyInfoDialog _propertyInfoDialog;
        private System.Windows.Forms.TableLayoutPanel _buttonsPanel;
        private List<Button> buttons = new List<Button>();
        private System.Windows.Forms.Button _ritiraDallaPartitaButton;
        private System.Windows.Forms.Button _pagaCauzioneButton;
        private System.Windows.Forms.Button _costruisciEdificioButton;
        private System.Windows.Forms.Button _demolisciEdificioButton;
        private System.Windows.Forms.Button _vendiTerrenoButton;
        private System.Windows.Forms.Button _pescaUnaCartaButton;
        private System.Windows.Forms.Button _acquistaUnTerrenoButton;
        private System.Windows.Forms.Button _tiraDadiButton;
        private System.Windows.Forms.Button _terminaTurnoButton;
        private System.Windows.Forms.Button _pagaTassaButton;
        private System.Windows.Forms.Button _pagaAffittoButton;
        private System.Windows.Forms.Button _pagaButton;        //pagamenti comandati da carte pescate
        private System.Windows.Forms.Label _labelGiocatore;
        private System.Windows.Forms.Button _visualizzaContrattoButton;
        private System.Windows.Forms.Button _visualizzaInformazioniButton;
        private System.Windows.Forms.Label _labelCapitale;
        private System.Windows.Forms.TextBox _logBox;
        private System.Windows.Forms.Label _labelPosizione;
        private System.Windows.Forms.Label _labelInPrigione;
        private System.Windows.Forms.Panel _pannelloSuperiore;
        private System.Windows.Forms.Label _timeLabel;
        private static string _giocatoreCorrente = "E' IL TURNO DI ";
        private static string _capitaleGiocatoreCorrente = "CAPITALE: ";
        private static string _posizioneGiocatoreCorrente = "POSIZIONE CORRENTE: ";
        private readonly string _currency;
        private static int _maxLogLines = 50;

        #endregion

        public ControlPanel(Point location, Size size, string name, Controller.GameController controller, 
            Partita partita, Deed[] deedPool, string currency)
        {
            this._controller = controller;
            this._partita = partita;
            this._deedPool = deedPool;
            this.Size = size;
            this.Location = location;
            this.Name = name;
            _currency = " "+currency;
            _deedInfoDialog = new DeedInfoDialog();
            _propertyInfoDialog = new PropertyInfoDialog(_partita.TavolaDaGioco.Caselle.OfType<Terreno>(), currency);
            _partita.PlayerChanged += this.CambioGiocatore;
            _partita.GameTimer += this.AggiornaTimer;
            foreach (Giocatore giocatore in _partita.Giocatori)
            {
                giocatore.MoneyChanged += this.AggiornaPannelloSuperiore;
                giocatore.PlayerQuit += this.AggiornaPannelloSuperiore;
                giocatore.PositionChanged += this.AggiornaPannelloSuperiore;
            }


            InitializeComponent();

            foreach (Monopoli.Model.Casella cell in this._partita.TavolaDaGioco.Caselle)
            {
                if (cell is Monopoli.Model.VaiInPrigione)
                {
                    ((Monopoli.Model.VaiInPrigione)cell).VaiInPrigioneEvent += SuCasellaVaiInPrigione;
                }
                else if (cell is Monopoli.Model.Terreno)
                {
                    ((Monopoli.Model.Terreno)cell).TerrenoEvent += SuCasellaTerreno;
                    if (cell is TerrenoNormale)
                        ((TerrenoNormale)cell).BuildingChanged += this.AggiornaPannelloSuperiore;
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
            foreach (Carta carta in _partita.TavolaDaGioco.Imprevisti)
            {
                RegistraEventiCarta(carta);
            }
            foreach (Carta carta in _partita.TavolaDaGioco.Probabilità)
            {
                RegistraEventiCarta(carta);
            }
            _labelGiocatore.Text = _giocatoreCorrente + _partita.GetGiocatoreCorrente().Nome;
            _labelCapitale.Text = _capitaleGiocatoreCorrente + _partita.GetGiocatoreCorrente().Capitale+ _currency;
            _labelPosizione.Text = _posizioneGiocatoreCorrente + _partita.GetGiocatoreCorrente().PosizioneCorrente.Nome;
            _labelInPrigione.Text = "";
        }

        #region buttonGetters

        public  Button TiraDadiButton
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
           get { return this._terminaTurnoButton;  }
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

        private void InitializeComponent()
        {
            this._buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this._tiraDadiButton = new System.Windows.Forms.Button();
            this.buttons.Add(_tiraDadiButton);
            this._terminaTurnoButton = new System.Windows.Forms.Button();
            this.buttons.Add(_terminaTurnoButton);
            this._pagaCauzioneButton = new System.Windows.Forms.Button();
            this.buttons.Add(_pagaCauzioneButton);
            this._pagaTassaButton = new System.Windows.Forms.Button();
            this.buttons.Add(_pagaTassaButton);
            this._pagaAffittoButton = new System.Windows.Forms.Button();
            this.buttons.Add(_pagaAffittoButton);
            this._pagaButton = new System.Windows.Forms.Button();
            this.buttons.Add(_pagaButton);
            this._acquistaUnTerrenoButton = new System.Windows.Forms.Button();
            this.buttons.Add(_acquistaUnTerrenoButton);
            this._vendiTerrenoButton = new System.Windows.Forms.Button();
            this.buttons.Add(_vendiTerrenoButton);
            this._costruisciEdificioButton = new System.Windows.Forms.Button();
            this.buttons.Add(_costruisciEdificioButton);
            this._demolisciEdificioButton = new System.Windows.Forms.Button();
            this.buttons.Add(_demolisciEdificioButton);
            this._visualizzaContrattoButton = new System.Windows.Forms.Button();
            this.buttons.Add(_visualizzaContrattoButton);
            this._visualizzaInformazioniButton = new System.Windows.Forms.Button();
            this.buttons.Add(_visualizzaInformazioniButton);
            this._pescaUnaCartaButton = new System.Windows.Forms.Button();
            this.buttons.Add(_pescaUnaCartaButton);
            this._ritiraDallaPartitaButton = new System.Windows.Forms.Button();
            this.buttons.Add(_ritiraDallaPartitaButton);

            this._labelGiocatore = new System.Windows.Forms.Label();
            this._logBox = new System.Windows.Forms.TextBox();
            this._labelPosizione = new System.Windows.Forms.Label();
            this._labelCapitale = new System.Windows.Forms.Label();
            this._labelInPrigione = new System.Windows.Forms.Label();
            this._timeLabel = new System.Windows.Forms.Label();
            this._pannelloSuperiore = new System.Windows.Forms.Panel();
            this._buttonsPanel.SuspendLayout();
            this._pannelloSuperiore.SuspendLayout();
            this.SuspendLayout();
            // 
            // _logBox
            // 
            this._logBox.BackColor = System.Drawing.Color.LightCyan;
            this._logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._logBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, 
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._logBox.Location = new System.Drawing.Point(0, 0);
            this._logBox.Multiline = true;
            this._logBox.Name = "_logBox";
            this._logBox.ReadOnly = true;
            this._logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._logBox.Size = new System.Drawing.Size(this.Size.Width, 160);
            this._logBox.TabIndex = 2;
            //
            // _timeLabel
            //
            this._timeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._timeLabel.Location = new System.Drawing.Point(0, 150);
            this._timeLabel.Name = "_timeLabel";
            this._timeLabel.Size = new System.Drawing.Size(this.Size.Width, 35);
            this._timeLabel.TabIndex = 20;
            this._timeLabel.Text = "";
            this._timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _pannelloSuperiore
            //
            this._pannelloSuperiore.BackColor = System.Drawing.Color.White;
            this._pannelloSuperiore.Dock = DockStyle.Top;
            this._pannelloSuperiore.Location = new System.Drawing.Point(0, 0);
            this._pannelloSuperiore.Name = "_pannelloSuperiore";
            this._pannelloSuperiore.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height / 2);
            this._pannelloSuperiore.TabIndex = 0;
            this._pannelloSuperiore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            // 
            // _buttonsPanel
            // 
            this._buttonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._buttonsPanel.ColumnCount = 2;
            this._buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            int rows = buttons.Count / 2 + buttons.Count % 2;
            float rowsWidth = 100F / (float)rows;

            this._buttonsPanel.RowCount = rows;
            for (int i = 0; i < rows; i++)
            {
                this._buttonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowsWidth));
                this._buttonsPanel.Controls.Add(buttons[2 * i], 0, i);
                this._buttonsPanel.Controls.Add(buttons[2 * i + 1], 1, i);
            }

            this._buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonsPanel.Location = new System.Drawing.Point(3, 109);
            this._buttonsPanel.Name = "_buttonsPanel";
            this._buttonsPanel.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height / 2);
            this._buttonsPanel.TabIndex = 0;
            // 
            // visualizzaContrattoButton
            // 
            this._visualizzaContrattoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._visualizzaContrattoButton.AutoSize = true;
            this._visualizzaContrattoButton.Location = new System.Drawing.Point(26, 88);
            this._visualizzaContrattoButton.Name = "visualizzaContrattoButton";
            this._visualizzaContrattoButton.Size = new System.Drawing.Size(122, 23);
            this._visualizzaContrattoButton.TabIndex = 10;
            this._visualizzaContrattoButton.Text = "Visualizza Contratto";
            this._visualizzaContrattoButton.UseVisualStyleBackColor = true;
            _visualizzaContrattoButton.Click += new EventHandler(VisualizzaContrattoButtonClick);
            // 
            // visualizzaInformazioniButton
            // 
            this._visualizzaInformazioniButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._visualizzaInformazioniButton.AutoSize = true;
            this._visualizzaInformazioniButton.Location = new System.Drawing.Point(200, 88);
            this._visualizzaInformazioniButton.Name = "visualizzaInformazioniButton";
            this._visualizzaInformazioniButton.Size = new System.Drawing.Size(122, 23);
            this._visualizzaInformazioniButton.TabIndex = 9;
            this._visualizzaInformazioniButton.Text = "Visualizza Informazioni";
            this._visualizzaInformazioniButton.UseVisualStyleBackColor = true;
            _visualizzaInformazioniButton.Click += new EventHandler(VisualizzaInformazioniButtonClick);
            // 
            // ritiraDallaPartitaButton
            // 
            this._ritiraDallaPartitaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._ritiraDallaPartitaButton.AutoSize = true;
            this._ritiraDallaPartitaButton.Location = new System.Drawing.Point(26, 211);
            this._ritiraDallaPartitaButton.Name = "ritiraDallaPartitaButton";
            this._ritiraDallaPartitaButton.Size = new System.Drawing.Size(122, 23);
            this._ritiraDallaPartitaButton.TabIndex = 11;
            this._ritiraDallaPartitaButton.Text = "Ritira dalla Partita";
            this._ritiraDallaPartitaButton.UseVisualStyleBackColor = true;
            _ritiraDallaPartitaButton.Click += new EventHandler(RitiraDallaPartitaButtonClick);
            // 
            // pagaCauzioneButton
            // 
            this._pagaCauzioneButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._pagaCauzioneButton.AutoSize = true;
            this._pagaCauzioneButton.Location = new System.Drawing.Point(200, 48);
            this._pagaCauzioneButton.Name = "pagaCauzioneButton";
            this._pagaCauzioneButton.Size = new System.Drawing.Size(122, 23);
            this._pagaCauzioneButton.TabIndex = 8;
            this._pagaCauzioneButton.Text = "Paga Cauzione";
            this._pagaCauzioneButton.UseVisualStyleBackColor = true;
            _pagaCauzioneButton.Click += new EventHandler(PagaCauzioneButtonClick);
            // 
            // costruisciEdificioButton
            // 
            this._costruisciEdificioButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._costruisciEdificioButton.AutoSize = true;
            this._costruisciEdificioButton.Location = new System.Drawing.Point(26, 168);
            this._costruisciEdificioButton.Name = "costruisciEdificioButton";
            this._costruisciEdificioButton.Size = new System.Drawing.Size(122, 23);
            this._costruisciEdificioButton.TabIndex = 6;
            this._costruisciEdificioButton.Text = "Costruisci Edificio";
            this._costruisciEdificioButton.UseVisualStyleBackColor = true;
            _costruisciEdificioButton.Click += new EventHandler(CostruisciEdificioButtonClick);
            // 
            // tiraDadiButton
            // 
            this._tiraDadiButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._tiraDadiButton.AutoSize = true;
            this._tiraDadiButton.Location = new System.Drawing.Point(26, 8);
            this._tiraDadiButton.Name = "tiraDadiButton";
            this._tiraDadiButton.Size = new System.Drawing.Size(122, 23);
            this._tiraDadiButton.TabIndex = 1;
            this._tiraDadiButton.Text = "Tira Dadi";
            this._tiraDadiButton.UseVisualStyleBackColor = true;
            _tiraDadiButton.Click += new EventHandler(TiraDadiButtonClick);
            // 
            // terminaTurnoButton
            // 
            this._terminaTurnoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._terminaTurnoButton.AutoSize = true;
            this._terminaTurnoButton.Location = new System.Drawing.Point(200, 8);
            this._terminaTurnoButton.Name = "terminaTurnoButton";
            this._terminaTurnoButton.Size = new System.Drawing.Size(122, 23);
            this._terminaTurnoButton.TabIndex = 2;
            this._terminaTurnoButton.Text = "Termina Turno";
            this._terminaTurnoButton.UseVisualStyleBackColor = true;
            _terminaTurnoButton.Click += new EventHandler(TerminaTurnoButtonClick);
            // 
            // pescaUnaCartaButton
            // 
            this._pescaUnaCartaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._pescaUnaCartaButton.AutoSize = true;
            this._pescaUnaCartaButton.Location = new System.Drawing.Point(26, 48);
            this._pescaUnaCartaButton.Name = "button4";
            this._pescaUnaCartaButton.Size = new System.Drawing.Size(122, 23);
            this._pescaUnaCartaButton.TabIndex = 3;
            this._pescaUnaCartaButton.Text = "Pesca una Carta";
            this._pescaUnaCartaButton.UseVisualStyleBackColor = true;
            _pescaUnaCartaButton.Click += new EventHandler(PescaUnaCartaButtonClick);
            // 
            // acquistaUnTerrenoButton
            // 
            this._acquistaUnTerrenoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._acquistaUnTerrenoButton.AutoSize = true;
            this._acquistaUnTerrenoButton.Location = new System.Drawing.Point(26, 128);
            this._acquistaUnTerrenoButton.Name = "acquistaTerrenoButton";
            this._acquistaUnTerrenoButton.Size = new System.Drawing.Size(122, 23);
            this._acquistaUnTerrenoButton.TabIndex = 4;
            this._acquistaUnTerrenoButton.Text = "Acquista Terreno";
            this._acquistaUnTerrenoButton.UseVisualStyleBackColor = true;
            _acquistaUnTerrenoButton.Click += new EventHandler(AcquistaUnTerrenoButtonClick);
            // 
            // vendiTerrenoButton
            // 
            this._vendiTerrenoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._vendiTerrenoButton.AutoSize = true;
            this._vendiTerrenoButton.Location = new System.Drawing.Point(200, 128);
            this._vendiTerrenoButton.Name = "vendiTerrenoButton";
            this._vendiTerrenoButton.Size = new System.Drawing.Size(122, 23);
            this._vendiTerrenoButton.TabIndex = 15;
            this._vendiTerrenoButton.Text = "Vendi Terreno";
            this._vendiTerrenoButton.UseVisualStyleBackColor = true;
            _vendiTerrenoButton.Click += new EventHandler(VendiTerrenoButtonClick);
            // 
            // demolisciEdificioButton
            // 
            this._demolisciEdificioButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._demolisciEdificioButton.AutoSize = true;
            this._demolisciEdificioButton.Location = new System.Drawing.Point(200, 168);
            this._demolisciEdificioButton.Name = "demolisciEdificioButton";
            this._demolisciEdificioButton.Size = new System.Drawing.Size(122, 23);
            this._demolisciEdificioButton.TabIndex = 7;
            this._demolisciEdificioButton.Text = "Demolisci Edificio";
            this._demolisciEdificioButton.UseVisualStyleBackColor = true;
            _demolisciEdificioButton.Click += new EventHandler(DemolisciEdificioButtonClick);
            // 
            // pagaTassaButton
            // 
            this._pagaTassaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._pagaTassaButton.AutoSize = true;
            this._pagaTassaButton.Location = new System.Drawing.Point(26, 88);
            this._pagaTassaButton.Name = "pagaTassaButton";
            this._pagaTassaButton.Size = new System.Drawing.Size(122, 23);
            this._pagaTassaButton.TabIndex = 14;
            this._pagaTassaButton.Text = "Paga Tassa";
            this._pagaTassaButton.UseVisualStyleBackColor = true;
            _pagaTassaButton.Click += new EventHandler(PagaTassaButtonClick);
            // 
            // pagaAffittoButton
            // 
            this._pagaAffittoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._pagaAffittoButton.AutoSize = true;
            this._pagaAffittoButton.Location = new System.Drawing.Point(26, 88);
            this._pagaAffittoButton.Name = "pagaAffittoButton";
            this._pagaAffittoButton.Size = new System.Drawing.Size(122, 23);
            this._pagaAffittoButton.TabIndex = 12;
            this._pagaAffittoButton.Text = "Paga Affitto";
            this._pagaAffittoButton.UseVisualStyleBackColor = true;
            _pagaAffittoButton.Click += new EventHandler(PagaAffittoButtonClick);
            // 
            // pagaButton
            // 
            this._pagaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._pagaButton.AutoSize = true;
            this._pagaButton.Location = new System.Drawing.Point(26, 88);
            this._pagaButton.Name = "pagaButton";
            this._pagaButton.Size = new System.Drawing.Size(122, 23);
            this._pagaButton.TabIndex = 13;
            this._pagaButton.Text = "Paga";
            this._pagaButton.UseVisualStyleBackColor = true;
            _pagaButton.Click += new EventHandler(PagaButtonClick);
            // 
            // _labelGiocatore
            // 
            this._labelGiocatore.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelGiocatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, 
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelGiocatore.Location = new System.Drawing.Point(0, 0);
            this._labelGiocatore.Name = "_labelGiocatore";
            this._labelGiocatore.Size = new System.Drawing.Size(this.Size.Width, 45);
            this._labelGiocatore.TabIndex = 0;
            this._labelGiocatore.Text = "E\' il turno di Player1";
            this._labelGiocatore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelCapitale
            // 
            this._labelCapitale.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelCapitale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, 
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelCapitale.Location = new System.Drawing.Point(0, 45);
            this._labelCapitale.Name = "_labelCapitale";
            this._labelCapitale.Size = new System.Drawing.Size(this.Size.Width, 35);
            this._labelCapitale.TabIndex = 1;
            this._labelCapitale.Text = "CAPITALE: xxx";
            this._labelCapitale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelPosizione
            // 
            this._labelPosizione.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelPosizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, 
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelPosizione.Location = new System.Drawing.Point(0, 80);
            this._labelPosizione.Name = "_labelPosizione";
            this._labelPosizione.Size = new System.Drawing.Size(this.Size.Width, 35);
            this._labelPosizione.TabIndex = 5;
            this._labelPosizione.Text = "POSIZIONE CORRENTE: xxx";
            this._labelPosizione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelInPrigione
            // 
            this._labelInPrigione.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelInPrigione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelInPrigione.Location = new System.Drawing.Point(0, 115);
            this._labelInPrigione.Name = "_labelInPrigione";
            this._labelInPrigione.Size = new System.Drawing.Size(this.Size.Width, 35);
            this._labelInPrigione.TabIndex = 6;
            this._labelInPrigione.Text = "IN PRIGIONE DA x TURNI";
            this._labelInPrigione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ControlPanel
            //
            this.BackColor = System.Drawing.Color.Gray;
            this._pannelloSuperiore.Controls.Add(_labelInPrigione);
            this._pannelloSuperiore.Controls.Add(_labelPosizione);
            this._pannelloSuperiore.Controls.Add(_labelCapitale);
            this._pannelloSuperiore.Controls.Add(_labelGiocatore);
            this._pannelloSuperiore.Controls.Add(_timeLabel);
            this._pannelloSuperiore.Controls.Add(_logBox);
            this.Controls.Add(this._buttonsPanel);
            this.Controls.Add(this._pannelloSuperiore);
            this._pannelloSuperiore.ResumeLayout();
            this._buttonsPanel.ResumeLayout(false);
            this._buttonsPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #region buttonsClicked

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
            Terreno terreno = (Terreno)_partita.GetGiocatoreCorrente().PosizioneCorrente;
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

        private void AggiornaPannelloSuperiore(object sender, LogEventArgs e)
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
            if (e.LogMessage != null)
            {
                AggiornaLog(e);
            }
        }

        private void CambioGiocatore(object sender, EventArgs e)
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
                _timeLabel.Text = "Tempo di Gioco rimanente: 0" + time.Hours+ ":";
            }
            else
            {
                _timeLabel.Text = "Tempo di Gioco rimanente: " + time.Hours + ":";
            }
            if (time.Minutes < 10)
            {
                _timeLabel.Text+= "0"+ time.Minutes;
            }
            else
            {
                _timeLabel.Text+= time.Minutes;
            }
        }

        public void OnDispose()
        {
            _deedInfoDialog.Dispose();
            _propertyInfoDialog.Dispose();
            this.Dispose();
        }
    }
}