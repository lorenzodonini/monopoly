using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoli.View
{
    class InitialDeedsDialog : Form
    {
        private static string _descriptionText = "Ha ottenuto i seguenti contratti:";
        private Label _nameLabel;
        private Label _totalPayedLabel;
        private Label _newMoneyLabel;
        private static string _totalPayedText = "Importo totale pagato: ";
        private static string _newMoneyText = "Nuovo Capitale: ";
        private FlowLayoutPanel _deedsPanel;

        public InitialDeedsDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._nameLabel = new Label();
            this._totalPayedLabel = new Label();
            this._newMoneyLabel = new Label();
            this._deedsPanel = new FlowLayoutPanel();
            Label _descriptionLabel = new Label();
            Button _confirmButton = new Button();
            this.SuspendLayout();
            //
            // _nameLabel
            //
            _nameLabel.Dock = DockStyle.Top;
            _nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _nameLabel.Location = new System.Drawing.Point(0,0);
            _nameLabel.Name = "nameLabel";
            _nameLabel.Size = new System.Drawing.Size(540, 45);
            _nameLabel.TabIndex = 0;
            _nameLabel.Text = "";
            _nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // _descriptionLabel
            //
            _descriptionLabel.Dock = DockStyle.Top;
            _descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _descriptionLabel.Location = new System.Drawing.Point(0, 45);
            _descriptionLabel.Name = "descriptionLabel";
            _descriptionLabel.Size = new System.Drawing.Size(540, 35);
            _descriptionLabel.TabIndex = 1;
            _descriptionLabel.Text = _descriptionText;
            _descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _deedsPanel
            //
            _deedsPanel.Dock = DockStyle.Top;
            _deedsPanel.BorderStyle = BorderStyle.Fixed3D;
            _deedsPanel.Location = new System.Drawing.Point(0, 80);
            _deedsPanel.Size = new System.Drawing.Size(540, 320);
            _deedsPanel.Name = "deedsPanel";
            _deedsPanel.AutoScroll = true;
            _deedsPanel.TabIndex = 2;
            //
            // _totalPayedLabel
            //
            _totalPayedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            _totalPayedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _totalPayedLabel.Location = new System.Drawing.Point(0, 400);
            _totalPayedLabel.Name = "totalPayedLabel";
            _totalPayedLabel.Size = new System.Drawing.Size(540, 35);
            _totalPayedLabel.TabIndex = 3;
            _totalPayedLabel.Text = "";
            _totalPayedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _newMoneyLabel
            //
            _newMoneyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            _newMoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _newMoneyLabel.Location = new System.Drawing.Point(0, 435);
            _newMoneyLabel.Name = "newMoneyLabel";
            _newMoneyLabel.Size = new System.Drawing.Size(540, 35);
            _newMoneyLabel.TabIndex = 4;
            _newMoneyLabel.Text = "";
            _newMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _confirmButton
            //
            _confirmButton.Location = new System.Drawing.Point(210, 472);
            _confirmButton.Name = "confirmButton";
            _confirmButton.Size = new System.Drawing.Size(120, 40);
            _confirmButton.TabIndex = 5;
            _confirmButton.Text = "OK";
            _confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            _confirmButton.UseVisualStyleBackColor = true;
            //
            // InitialDeedDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 515);
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(_newMoneyLabel);
            this.Controls.Add(_totalPayedLabel);
            this.Controls.Add(_deedsPanel);
            this.Controls.Add(_descriptionLabel);
            this.Controls.Add(_nameLabel);
            this.Controls.Add(_confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitialDeedDialog";
            this.Text = "InizioPartita";
            this.ResumeLayout(false);
        }

        public void SetName(string name)
        {
            _nameLabel.Text = name;
        }

        public void SetTotalPayed(decimal total, string currency)
        {
            _totalPayedLabel.Text = _totalPayedText + currency + " " + total;
        }

        public void SetNewMoney(decimal newMoney, string currency)
        {
            _newMoneyLabel.Text = _newMoneyText + currency + " " + newMoney;
        }

        public void SetDeeds(Deed[] deeds)
        {
            _deedsPanel.Controls.Clear();
            foreach (Deed deed in deeds)
            {
                _deedsPanel.Controls.Add(deed);
            }
        }
    }
}
