namespace Monopoli.View
{
    partial class GameStatisticsDialog
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._headLabel = new System.Windows.Forms.Label();
            this._statisticsPanel = new System.Windows.Forms.TableLayoutPanel();
            this._column8Label = new System.Windows.Forms.Label();
            this._column7Label = new System.Windows.Forms.Label();
            this._column6Label = new System.Windows.Forms.Label();
            this._column5Label = new System.Windows.Forms.Label();
            this._column4Label = new System.Windows.Forms.Label();
            this._column2Label = new System.Windows.Forms.Label();
            this._column1Label = new System.Windows.Forms.Label();
            this._column3Label = new System.Windows.Forms.Label();
            this._winnerLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._statisticsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _headLabel
            // 
            this._headLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._headLabel.Location = new System.Drawing.Point(0, 0);
            this._headLabel.Name = "_headLabel";
            this._headLabel.Size = new System.Drawing.Size(834, 31);
            this._headLabel.TabIndex = 1;
            this._headLabel.Text = "La Partita è Terminata!";
            this._headLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _statisticsPanel
            // 
            this._statisticsPanel.AutoScroll = true;
            this._statisticsPanel.AutoSize = true;
            this._statisticsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this._statisticsPanel.ColumnCount = 8;
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this._statisticsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this._statisticsPanel.Controls.Add(this._column8Label, 7, 0);
            this._statisticsPanel.Controls.Add(this._column7Label, 6, 0);
            this._statisticsPanel.Controls.Add(this._column6Label, 5, 0);
            this._statisticsPanel.Controls.Add(this._column5Label, 4, 0);
            this._statisticsPanel.Controls.Add(this._column4Label, 3, 0);
            this._statisticsPanel.Controls.Add(this._column2Label, 1, 0);
            this._statisticsPanel.Controls.Add(this._column1Label, 0, 0);
            this._statisticsPanel.Controls.Add(this._column3Label, 2, 0);
            this._statisticsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._statisticsPanel.Location = new System.Drawing.Point(0, 31);
            this._statisticsPanel.MaximumSize = new System.Drawing.Size(834, 234);
            this._statisticsPanel.Name = "_statisticsPanel";
            this._statisticsPanel.RowCount = 1;
            this._statisticsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this._statisticsPanel.Size = new System.Drawing.Size(834, 61);
            this._statisticsPanel.TabIndex = 2;
            // 
            // _column8Label
            // 
            this._column8Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column8Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column8Label.Location = new System.Drawing.Point(731, 3);
            this._column8Label.Name = "_column8Label";
            this._column8Label.Size = new System.Drawing.Size(97, 55);
            this._column8Label.TabIndex = 7;
            this._column8Label.Text = "Valore Totale";
            this._column8Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column7Label
            // 
            this._column7Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column7Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column7Label.Location = new System.Drawing.Point(616, 3);
            this._column7Label.Name = "_column7Label";
            this._column7Label.Size = new System.Drawing.Size(106, 55);
            this._column7Label.TabIndex = 6;
            this._column7Label.Text = "Valore complessivo Edifici";
            this._column7Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column6Label
            // 
            this._column6Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column6Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column6Label.Location = new System.Drawing.Point(517, 3);
            this._column6Label.Name = "_column6Label";
            this._column6Label.Size = new System.Drawing.Size(90, 55);
            this._column6Label.TabIndex = 5;
            this._column6Label.Text = "Numero Alberghi posseduti";
            this._column6Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column5Label
            // 
            this._column5Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column5Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column5Label.Location = new System.Drawing.Point(418, 3);
            this._column5Label.Name = "_column5Label";
            this._column5Label.Size = new System.Drawing.Size(90, 55);
            this._column5Label.TabIndex = 4;
            this._column5Label.Text = "Numero Case possedute";
            this._column5Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column4Label
            // 
            this._column4Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column4Label.Location = new System.Drawing.Point(303, 3);
            this._column4Label.Name = "_column4Label";
            this._column4Label.Size = new System.Drawing.Size(106, 55);
            this._column4Label.TabIndex = 3;
            this._column4Label.Text = "Valore complessivo Terreni";
            this._column4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column2Label
            // 
            this._column2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column2Label.Location = new System.Drawing.Point(113, 3);
            this._column2Label.Name = "_column2Label";
            this._column2Label.Size = new System.Drawing.Size(82, 55);
            this._column2Label.TabIndex = 2;
            this._column2Label.Text = "Capitale";
            this._column2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column1Label
            // 
            this._column1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column1Label.Location = new System.Drawing.Point(6, 3);
            this._column1Label.Name = "_column1Label";
            this._column1Label.Size = new System.Drawing.Size(98, 55);
            this._column1Label.TabIndex = 1;
            this._column1Label.Text = "Giocatore";
            this._column1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _column3Label
            // 
            this._column3Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this._column3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._column3Label.Location = new System.Drawing.Point(204, 3);
            this._column3Label.Name = "_column3Label";
            this._column3Label.Size = new System.Drawing.Size(90, 55);
            this._column3Label.TabIndex = 0;
            this._column3Label.Text = "Numero Terreni posseduti";
            this._column3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _winnerLabel
            // 
            this._winnerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._winnerLabel.Location = new System.Drawing.Point(0, 92);
            this._winnerLabel.Name = "_winnerLabel";
            this._winnerLabel.Size = new System.Drawing.Size(834, 52);
            this._winnerLabel.TabIndex = 3;
            this._winnerLabel.Text = "Il vincitore della partita è PLAYER1";
            this._winnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(345, 333);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(150, 30);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // GameStatisticsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 375);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._winnerLabel);
            this.Controls.Add(this._statisticsPanel);
            this.Controls.Add(this._headLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameStatisticsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistiche della Partita";
            this._statisticsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _headLabel;
        private System.Windows.Forms.TableLayoutPanel _statisticsPanel;
        private System.Windows.Forms.Label _winnerLabel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label _column2Label;
        private System.Windows.Forms.Label _column1Label;
        private System.Windows.Forms.Label _column3Label;
        private System.Windows.Forms.Label _column7Label;
        private System.Windows.Forms.Label _column6Label;
        private System.Windows.Forms.Label _column5Label;
        private System.Windows.Forms.Label _column4Label;
        private System.Windows.Forms.Label _column8Label;
    }
}