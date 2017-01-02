using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    public class SpecialPropertyDeed : Deed
    {
        private Image _image;
        private string _groupName;

        public SpecialPropertyDeed(int id, string name, decimal value, decimal sellValue, decimal[] rentValues, string groupName, Image image, string currency)
            :base(id, name, value, sellValue, rentValues, currency)
        {
            _name = name;
            _image = image;
            _value = value;
            _sellValue = sellValue;
            _rentValues = rentValues;
            _groupName = groupName;
            _currencySymbol = currency;
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Label _valueLabel = new Label();
            Label _nameLabel = new Label();
            TableLayoutPanel _rentDataPanel = new TableLayoutPanel();
            PictureBox _picture = new PictureBox();
            this.SuspendLayout();
            //
            // _valueLabel
            //
            _valueLabel.Dock = DockStyle.Top;
            _valueLabel.Name = "valueLabel";
            _valueLabel.Location = new System.Drawing.Point(0, 0);
            _valueLabel.Size = new System.Drawing.Size(250, 15);
            _valueLabel.TabIndex = 0;
            _valueLabel.Text = "Valore " + _currencySymbol + " " + _value;
            _valueLabel.TextAlign = ContentAlignment.MiddleRight;
            _valueLabel.Font = _valueFont;
            //
            // _nameLabel
            //
            _nameLabel.Dock = DockStyle.Top;
            _nameLabel.Name = "nameLabel";
            _nameLabel.Location = new System.Drawing.Point(0, 15);
            _nameLabel.Size = new System.Drawing.Size(250, 45);
            _nameLabel.TabIndex = 1;
            _nameLabel.Text = _name.ToUpper();
            _nameLabel.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // _picture
            //
            _picture.Dock = DockStyle.Top;
            _picture.Location = new System.Drawing.Point(0, 60);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size(250, 105);
            _picture.Name = "picture";
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            _picture.PerformLayout();
            //
            // _rentDataPanel
            //
            _rentDataPanel.Dock = DockStyle.Bottom;
            _rentDataPanel.Location = new System.Drawing.Point(0, 165);
            _rentDataPanel.Size = new System.Drawing.Size(250, 125);
            _rentDataPanel.Name = "rentDataPanel";
            _rentDataPanel.TabIndex = 2;
            _rentDataPanel.ColumnCount = 2;
            _rentDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            _rentDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            _rentDataPanel.RowCount = _rentValues.Length + 1;
            float heightPercentage = 100 / _rentDataPanel.RowCount;
            int i=0;
            _rentDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
            Label rentDescriptionLabel = new Label();
            rentDescriptionLabel.Dock = DockStyle.Fill;
            Label rentValueLabel = new Label();
            rentValueLabel.Dock = DockStyle.Fill;
            rentDescriptionLabel.Text = "Affitto";
            rentValueLabel.Text = _currencySymbol+" "+_rentValues[i].ToString();
            rentDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            rentDescriptionLabel.Font = _valueFont;
            rentValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            rentValueLabel.Font = _valueFont;
            _rentDataPanel.Controls.Add(rentDescriptionLabel);
            _rentDataPanel.Controls.Add(rentValueLabel);
            for (i=1; i<_rentValues.Length; i++)
            {
                _rentDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
                rentDescriptionLabel = new Label();
                rentDescriptionLabel.Dock = DockStyle.Fill;
                rentValueLabel = new Label();
                rentValueLabel.Dock = DockStyle.Fill;
                rentDescriptionLabel.Text = "Se si possiedono " + (i + 1) +" "+ _groupName;
                rentValueLabel.Text = _currencySymbol + " " + _rentValues[i].ToString();
                rentDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
                rentValueLabel.TextAlign = ContentAlignment.MiddleCenter;
                rentValueLabel.Font = _valueFont;
                _rentDataPanel.Controls.Add(rentDescriptionLabel);
                _rentDataPanel.Controls.Add(rentValueLabel);
            }
            _rentDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
            rentDescriptionLabel = new Label();
            rentDescriptionLabel.Dock = DockStyle.Fill;
            rentValueLabel = new Label();
            rentValueLabel.Dock = DockStyle.Fill;
            rentDescriptionLabel.Text = "Valore di Vendita";
            rentValueLabel.Text = _currencySymbol + " " + _sellValue.ToString();
            rentDescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            rentValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            rentDescriptionLabel.Font = _valueFont;
            rentValueLabel.Font = _valueFont;
            _rentDataPanel.Controls.Add(rentDescriptionLabel);
            _rentDataPanel.Controls.Add(rentValueLabel);
            //
            // SpecialPropertyDeed
            //
            this.Controls.Add(_picture);
            this.Controls.Add(_nameLabel);
            this.Controls.Add(_valueLabel);
            this.Controls.Add(_rentDataPanel);
            this.Name = _name;
            this.ResumeLayout(false);
        }
    }
}
