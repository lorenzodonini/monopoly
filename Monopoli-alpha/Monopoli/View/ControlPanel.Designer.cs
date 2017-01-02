using System.Collections.Generic;
using System.Windows.Forms;
using System;
namespace Monopoli.View
{
    partial class ControlPanel
    {
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
        private System.Windows.Forms.Button _visualizzaContrattoButton;
        private System.Windows.Forms.Button _visualizzaInformazioniButton;
        private List<Button> buttons = new List<Button>();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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

            this.SuspendLayout();
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
            // ControlPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(231)))), ((int)(((byte)(206)))));
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            int rows = buttons.Count / 2 + buttons.Count % 2;
            float rowsWidth = 100F / (float)rows;

            this.RowCount = rows;
            for (int i = 0; i < rows; i++)
            {
                this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, rowsWidth));
                this.Controls.Add(buttons[2 * i], 0, i);
                this.Controls.Add(buttons[2 * i + 1], 1, i);
            }

            this.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Name = "ControlPanel";
            this.TabIndex = 0;
            this.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
