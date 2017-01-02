using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    public class CommonPropertyDeed : Deed
    {
        private decimal _houseCost;
        private static string _doubleRentInfo = "Se un giocatore possiede tutti i terreni d'uno stesso Gruppo (colore), " +
            "l'affitto del solo terreno viene raddoppiato.";

        public CommonPropertyDeed(int id, string name, decimal value, decimal sellValue, decimal[] rentValues, string groupColor, decimal houseCost, string currency)
            :base(id, name, value, sellValue, rentValues, currency, groupColor)
        {
            _houseCost = houseCost;
            InitializeComponent();
        }

        protected decimal HouseCost
        {
            get { return _houseCost; }
        }

        #region Component init
        private void InitializeComponent()
        {
            Label _valueLabel = new Label();
            Label _nameLabel = new Label();
            TableLayoutPanel _rentDataPanel = new TableLayoutPanel();
            Label _doubleRentLabel = new Label();
            TableLayoutPanel _houseCostPanel = new TableLayoutPanel();
            this.SuspendLayout();
            //
            // _valueLabel
            //
            _valueLabel.Dock = DockStyle.Top;
            _valueLabel.Name = "valueLabel";
            _valueLabel.Location = new System.Drawing.Point(0, 0);
            _valueLabel.Size = new System.Drawing.Size(250, 15);
            _valueLabel.TabIndex = 0;
            _valueLabel.Text = "Valore " + _currencySymbol + " " + Value;
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
            _nameLabel.Text = DeedName.ToUpper();
            _nameLabel.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            _nameLabel.BackColor = Color.FromName(Group);
            //
            // _rentDataPanel
            //
            _rentDataPanel.Dock = DockStyle.Top;
            _rentDataPanel.Location = new System.Drawing.Point(0, 60);
            _rentDataPanel.Size = new System.Drawing.Size(250, 120);
            _rentDataPanel.Name = "rentDataPanel";
            _rentDataPanel.TabIndex = 2;
            _rentDataPanel.ColumnCount = 2;
            _rentDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            _rentDataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            _rentDataPanel.RowCount = RentValues.Length;
            float heightPercentage = 100 / _rentDataPanel.RowCount;
            int i = 0;
            _rentDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
            Label descriptionLabel = new Label();
            descriptionLabel.Dock = DockStyle.Fill;
            Label valueLabel = new Label();
            valueLabel.Dock = DockStyle.Fill;
            descriptionLabel.Text = "Affitto - Solo Terreno";
            valueLabel.Text = _currencySymbol + " " + RentValues[i].ToString();
            descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            descriptionLabel.Font = _valueFont;
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;
            valueLabel.Font = _valueFont;
            _rentDataPanel.Controls.Add(descriptionLabel);
            _rentDataPanel.Controls.Add(valueLabel);
            for (i = 1; i < RentValues.Length; i++)
            {
                _rentDataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
                descriptionLabel = new Label();
                descriptionLabel.Dock = DockStyle.Fill;
                valueLabel = new Label();
                valueLabel.Dock = DockStyle.Fill;
                if (i == 1)
                {
                    descriptionLabel.Text = "Affitto - Con " + i + " Casa";
                }
                else if (i == RentValues.Length - 1)
                {
                    descriptionLabel.Text = "Affitto - Con Albergo";
                }
                else
                {
                    descriptionLabel.Text = "Affitto - Con " + i + " Case";
                }
                valueLabel.Text = _currencySymbol + " " + RentValues[i].ToString();
                descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
                valueLabel.TextAlign = ContentAlignment.MiddleCenter;
                valueLabel.Font = _valueFont;
                _rentDataPanel.Controls.Add(descriptionLabel);
                _rentDataPanel.Controls.Add(valueLabel);
            }
            //
            // _doubleRentLabel
            //
            _doubleRentLabel.Dock = DockStyle.Bottom;
            _doubleRentLabel.Name = "doubleRentLabel";
            _doubleRentLabel.TabIndex = 3;
            _doubleRentLabel.Location = new System.Drawing.Point(0, 180);
            _doubleRentLabel.Size = new System.Drawing.Size(250, 45);
            _doubleRentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _doubleRentLabel.Text = _doubleRentInfo;
            _doubleRentLabel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // _houseCostPanel
            //
            _houseCostPanel.Dock = DockStyle.Bottom;
            _houseCostPanel.Location = new System.Drawing.Point(0, 220);
            _houseCostPanel.Size = new System.Drawing.Size(250, 75);
            _houseCostPanel.Name = "houseCostPanel";
            _houseCostPanel.TabIndex = 4;
            _houseCostPanel.ColumnCount = 2;
            _houseCostPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            _houseCostPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            _houseCostPanel.RowCount = 3;
            heightPercentage = 100 / _houseCostPanel.RowCount;
            _houseCostPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
            descriptionLabel = new Label();
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.Text = "Costo di ogni Casa";
            valueLabel = new Label();
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Text = _currencySymbol + " " + _houseCost;
            valueLabel.Font = _valueFont;
            descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;
            _houseCostPanel.Controls.Add(descriptionLabel);
            _houseCostPanel.Controls.Add(valueLabel);

            _houseCostPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
            descriptionLabel = new Label();
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.Text = "Costo di un Albergo più " + (RentValues.Length - 1) + " Case";
            valueLabel = new Label();
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Text = _currencySymbol + " " + _houseCost;
            valueLabel.Font = _valueFont;
            descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;
            _houseCostPanel.Controls.Add(descriptionLabel);
            _houseCostPanel.Controls.Add(valueLabel);

            _houseCostPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, heightPercentage));
            descriptionLabel = new Label();
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.Text = "Valore di Vendita";
            descriptionLabel.Font = _valueFont;
            valueLabel = new Label();
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Font = _valueFont;
            valueLabel.Text = _currencySymbol + " " + SellValue;
            descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            valueLabel.TextAlign = ContentAlignment.MiddleCenter;
            _houseCostPanel.Controls.Add(descriptionLabel);
            _houseCostPanel.Controls.Add(valueLabel);
            //
            // CommonPropertyDeed
            //
            this.Controls.Add(_doubleRentLabel);
            this.Controls.Add(_houseCostPanel);
            this.Controls.Add(_rentDataPanel);
            this.Controls.Add(_nameLabel);
            this.Controls.Add(_valueLabel);
            this.Name = DeedName;
            this.ResumeLayout(false);
        }
        #endregion
    }
}
