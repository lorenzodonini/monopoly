using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoli.View
{
    public partial class SellPropertyDialog : Form
    {
        private Model.Terreno _toSell;
        private List<Model.Terreno> _terreni;
        private string _currency;

        public SellPropertyDialog(string currency)
        {
            _currency = currency+" ";
            InitializeComponent();
        }

        public DialogResult ShowDialogWithData(List<Model.Terreno> terreni, string playerName)
        {
            _terreni = terreni;
            _playerNameLabel.Text = playerName;
            _propertyList.Items.Clear();
            foreach (Model.Terreno terreno in _terreni)
            {
                _propertyList.Items.Add(terreno.Nome);
            }
            _propertyList.ClearSelected();
            _okButton.Enabled = false;
            _questionLabel.Text = "";
            _propertyValueLabel.Text = "";
            return base.ShowDialog();
        }

        public Model.Terreno ToSell
        {
            get { return _toSell; }
        }

        private void SelectedProperty_Changed(object sender, EventArgs e)
        {
            if (_propertyList.SelectedItem != null)
            {
                string selected = (string)_propertyList.SelectedItem;
                _toSell = _terreni.Single(terreno => terreno.Nome == selected);
            }
            else
            {
                _okButton.Enabled = false;
                _questionLabel.Text = "";
                _propertyValueLabel.Text = "";
                return;
            }
            _propertyValueLabel.Text = "Vendendo questo Terreno la Banca pagherà una somma di\n" + _currency + _toSell.ValoreDiVendita;
            _questionLabel.Text = "Sei sicuro di voler vendere " + _toSell.Nome + "?";
            _okButton.Enabled = true;
        }
    }
}
