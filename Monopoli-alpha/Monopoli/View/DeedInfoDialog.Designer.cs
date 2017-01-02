namespace Monopoli.View
{
    partial class DeedInfoDialog
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
            this._deedInfoPanel = new System.Windows.Forms.Panel();
            this._propertyList = new System.Windows.Forms.ListBox();
            this._infoLabel = new System.Windows.Forms.Label();
            this._playerName = new System.Windows.Forms.Label();
            this._returnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _deedInfoPanel
            // 
            this._deedInfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._deedInfoPanel.Location = new System.Drawing.Point(229, 0);
            this._deedInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            this._deedInfoPanel.Name = "_deedInfoPanel";
            this._deedInfoPanel.Padding = new System.Windows.Forms.Padding(5);
            this._deedInfoPanel.Size = new System.Drawing.Size(270, 315);
            this._deedInfoPanel.TabIndex = 1;
            // 
            // _propertyList
            // 
            this._propertyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._propertyList.FormattingEnabled = true;
            this._propertyList.ItemHeight = 16;
            this._propertyList.Location = new System.Drawing.Point(12, 99);
            this._propertyList.Name = "_propertyList";
            this._propertyList.ScrollAlwaysVisible = true;
            this._propertyList.Size = new System.Drawing.Size(197, 164);
            this._propertyList.TabIndex = 2;
            this._propertyList.SelectedIndexChanged += new System.EventHandler(this.SelectedProperty_Changed);
            // 
            // _infoLabel
            // 
            this._infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._infoLabel.Location = new System.Drawing.Point(14, 36);
            this._infoLabel.Name = "_infoLabel";
            this._infoLabel.Size = new System.Drawing.Size(196, 60);
            this._infoLabel.TabIndex = 3;
            this._infoLabel.Text = "Selezionare uno tra i terreni posseduti:";
            this._infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _playerName
            // 
            this._playerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._playerName.Location = new System.Drawing.Point(13, 9);
            this._playerName.Name = "_playerName";
            this._playerName.Size = new System.Drawing.Size(196, 27);
            this._playerName.TabIndex = 4;
            this._playerName.Text = "PLAYER1";
            this._playerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _returnButton
            // 
            this._returnButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._returnButton.Location = new System.Drawing.Point(12, 275);
            this._returnButton.Name = "_returnButton";
            this._returnButton.Size = new System.Drawing.Size(197, 25);
            this._returnButton.TabIndex = 5;
            this._returnButton.Text = "Torna alla Partita";
            this._returnButton.UseVisualStyleBackColor = true;
            // 
            // DeedInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 315);
            this.Controls.Add(this._returnButton);
            this.Controls.Add(this._playerName);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._propertyList);
            this.Controls.Add(this._deedInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeedInfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizza Contratto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _deedInfoPanel;
        private System.Windows.Forms.ListBox _propertyList;
        private System.Windows.Forms.Label _infoLabel;
        private System.Windows.Forms.Label _playerName;
        private System.Windows.Forms.Button _returnButton;
    }
}