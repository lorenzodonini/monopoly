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
    public partial class PropertyInfoDialog : Form
    {
        private IEnumerable<Model.Terreno> _terreni;
        private string _currency;

        public PropertyInfoDialog(IEnumerable<Model.Terreno> terreni, string currency)
        {
            _terreni = terreni;
            _currency = currency+" ";
            InitializeComponent();
            _propertyList.Items.Clear();
            foreach (Model.Terreno terreno in _terreni)
            {
                _propertyList.Items.Add(terreno.Nome);
            }
            _propertyList.ClearSelected();
            _propertyDataLabel.Text = "";
            _propertyOwnerLabel.Text = "";
        }

        private void SelectedProperty_Changed(object sender, EventArgs e)
        {
            Model.Terreno toShow = null;
            if (_propertyList.SelectedItem != null)
            {
                string selected = (string)_propertyList.SelectedItem;
                toShow = _terreni.Single(terreno => terreno.Nome == selected);
            }
            else
            {
                _propertyDataLabel.Text = "";
                _propertyOwnerLabel.Text = "";
                return;
            }
            if (toShow.Proprietario == null)
            {
                _propertyOwnerLabel.Text = toShow.Nome + " appartiene alla Banca";
                _propertyDataLabel.Text = "Valore del Terreno: " +_currency + toShow.Valore + "\nAffitto base: " + _currency + toShow.ValoriDiAffitto[0];
            }
            else
            {
                _propertyOwnerLabel.Text = "Proprietario: " + toShow.Proprietario.Nome;
                _propertyDataLabel.Text = "Informazioni non disponibili!";
            }
        }
    }
}
