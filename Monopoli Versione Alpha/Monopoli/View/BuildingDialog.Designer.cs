namespace Monopoli.View
{
    partial class BuildingDialog
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
            this._propertyList = new System.Windows.Forms.ListBox();
            this._infoLabel = new System.Windows.Forms.Label();
            this._playerNameLabel = new System.Windows.Forms.Label();
            this._returnButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._currentStatusLabel = new System.Windows.Forms.Label();
            this._buildingValueLabel = new System.Windows.Forms.Label();
            this._questionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _propertyList
            // 
            this._propertyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._propertyList.FormattingEnabled = true;
            this._propertyList.ItemHeight = 16;
            this._propertyList.Location = new System.Drawing.Point(20, 74);
            this._propertyList.Name = "_propertyList";
            this._propertyList.ScrollAlwaysVisible = true;
            this._propertyList.Size = new System.Drawing.Size(162, 164);
            this._propertyList.TabIndex = 0;
            this._propertyList.SelectedIndexChanged += new System.EventHandler(this.SelectedProperty_Changed);
            // 
            // _infoLabel
            // 
            this._infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._infoLabel.Location = new System.Drawing.Point(17, 40);
            this._infoLabel.Name = "_infoLabel";
            this._infoLabel.Size = new System.Drawing.Size(395, 31);
            this._infoLabel.TabIndex = 1;
            this._infoLabel.Text = "Selezionare un Terreno su cui costruire un Edificio:";
            this._infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _playerNameLabel
            // 
            this._playerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._playerNameLabel.Location = new System.Drawing.Point(17, 9);
            this._playerNameLabel.Name = "_playerNameLabel";
            this._playerNameLabel.Size = new System.Drawing.Size(395, 31);
            this._playerNameLabel.TabIndex = 2;
            this._playerNameLabel.Text = "PLAYER1";
            this._playerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _returnButton
            // 
            this._returnButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._returnButton.Location = new System.Drawing.Point(20, 258);
            this._returnButton.Name = "_returnButton";
            this._returnButton.Size = new System.Drawing.Size(190, 25);
            this._returnButton.TabIndex = 4;
            this._returnButton.Text = "Torna alla Partita";
            this._returnButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(222, 258);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(190, 25);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "Costruisci Edificio";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _currentStatusLabel
            // 
            this._currentStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._currentStatusLabel.Location = new System.Drawing.Point(192, 75);
            this._currentStatusLabel.Name = "_currentStatusLabel";
            this._currentStatusLabel.Size = new System.Drawing.Size(219, 50);
            this._currentStatusLabel.TabIndex = 6;
            this._currentStatusLabel.Text = "label3";
            this._currentStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _buildingValueLabel
            // 
            this._buildingValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._buildingValueLabel.Location = new System.Drawing.Point(193, 125);
            this._buildingValueLabel.Name = "_buildingValueLabel";
            this._buildingValueLabel.Size = new System.Drawing.Size(219, 50);
            this._buildingValueLabel.TabIndex = 7;
            this._buildingValueLabel.Text = "label4";
            this._buildingValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _questionLabel
            // 
            this._questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._questionLabel.Location = new System.Drawing.Point(194, 198);
            this._questionLabel.Name = "_questionLabel";
            this._questionLabel.Size = new System.Drawing.Size(218, 40);
            this._questionLabel.TabIndex = 8;
            this._questionLabel.Text = "label1";
            this._questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BuildingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 295);
            this.Controls.Add(this._questionLabel);
            this.Controls.Add(this._buildingValueLabel);
            this.Controls.Add(this._currentStatusLabel);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._returnButton);
            this.Controls.Add(this._playerNameLabel);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._propertyList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Costruzione Edificio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _propertyList;
        private System.Windows.Forms.Label _infoLabel;
        private System.Windows.Forms.Label _playerNameLabel;
        private System.Windows.Forms.Button _returnButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label _currentStatusLabel;
        private System.Windows.Forms.Label _buildingValueLabel;
        private System.Windows.Forms.Label _questionLabel;
    }
}