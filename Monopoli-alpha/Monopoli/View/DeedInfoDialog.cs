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
    public partial class DeedInfoDialog : Form
    {
        private Dictionary<string, int> _properties; //id + name
        private Deed[] _deeds;

        public DeedInfoDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialogWithData(String playerName, List<Model.Terreno> terreni, Deed[] deeds)
        {
            if (_properties == null)
            {
                _properties = new Dictionary<string, int>();
            }
            else
            {
                _properties.Clear();
            }
            foreach (Model.Terreno terreno in terreni)
            {
                _properties.Add(terreno.Nome, terreno.ID);
            }
            _deeds = deeds;
            _playerName.Text = playerName;
            _deedInfoPanel.Controls.Clear();
            _propertyList.Items.Clear();
            _propertyList.Items.AddRange(_properties.Keys.ToArray<string>());
            _propertyList.ClearSelected();
            return base.ShowDialog();
        }

        #region EventHandler
        private void SelectedProperty_Changed(object sender, EventArgs e)
        {
            int selectedId = -1;
            if (_propertyList.SelectedItem != null)
            {
                string selected = (string)_propertyList.SelectedItem;
                selectedId = _properties[selected];
            }
            else
            {
                _deedInfoPanel.Controls.Clear();
                return;
            }
            _deedInfoPanel.Controls.Clear();
            for (int i = 0; i < _deeds.Length; i++)
            {
                if (_deeds[i].ID == selectedId)
                {
                    _deeds[i].Dock = DockStyle.Left;
                    _deedInfoPanel.Controls.Add(_deeds[i]);
                    break;
                }
            }
        }
        #endregion
    }
}
