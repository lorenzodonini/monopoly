namespace Monopoli.View
{
    partial class GameInfoPanel
    {
        private System.Windows.Forms.Label _labelGiocatore;
        private System.Windows.Forms.Label _labelCapitale;
        private System.Windows.Forms.TextBox _logBox;
        private System.Windows.Forms.Label _labelPosizione;
        private System.Windows.Forms.Label _labelInPrigione;
        private System.Windows.Forms.Label _labelTempo;
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
            this._labelGiocatore = new System.Windows.Forms.Label();
            this._logBox = new System.Windows.Forms.TextBox();
            this._labelPosizione = new System.Windows.Forms.Label();
            this._labelCapitale = new System.Windows.Forms.Label();
            this._labelInPrigione = new System.Windows.Forms.Label();
            this._labelTempo = new System.Windows.Forms.Label();
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
            this._labelTempo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._labelTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTempo.Location = new System.Drawing.Point(0, 150);
            this._labelTempo.Name = "_timeLabel";
            this._labelTempo.Size = new System.Drawing.Size(this.Size.Width, 35);
            this._labelTempo.TabIndex = 20;
            this._labelTempo.Text = "";
            this._labelTempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // GameInfoPanel
            //
            this.BackColor = System.Drawing.Color.White;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "GameInfoPanel";
            this.TabIndex = 0;

            this.Controls.Add(_labelInPrigione);
            this.Controls.Add(_labelPosizione);
            this.Controls.Add(_labelCapitale);
            this.Controls.Add(_labelGiocatore);
            this.Controls.Add(_labelTempo);
            this.Controls.Add(_logBox);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
