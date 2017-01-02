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
    public partial class BuildingDialog : Form
    {
        public enum Action { BUILD, DEMOLISH };
        private List<Model.TerrenoNormale> _terreni;
        private Model.TerrenoNormale _toModify;
        private string _currency;
        private Action _action;

        public BuildingDialog(string currency)
        {
            _currency = currency+" ";
            InitializeComponent();
        }

        public Model.TerrenoNormale ToModify
        {
            get { return _toModify; }
        }

        public DialogResult ShowDialogWithData(List<Model.TerrenoNormale> terreni, Action action, string playerName)
        {
            _playerNameLabel.Text = playerName;
            _terreni = terreni;
            _action = action;
            if (_action == Action.BUILD)
            {
                this.Name = "Costruzione Edificio";
                _okButton.Text = "Costruisci Edificio";
            }
            else if (_action == Action.DEMOLISH)
            {
                this.Name = "Demolizione Edificio";
                _okButton.Text = "Demolisci Edificio";
            }
            _okButton.Enabled = false;
            _propertyList.Items.Clear();
            foreach (Model.TerrenoNormale terreno in _terreni)
            {
                _propertyList.Items.Add(terreno.Nome);
            }
            _propertyList.ClearSelected();
            _currentStatusLabel.Text = "";
            _buildingValueLabel.Text = "";
            _questionLabel.Text = "";
            return base.ShowDialog();
        }

        private void SelectedProperty_Changed(object sender, EventArgs e)
        {
            if (_propertyList.SelectedItem != null)
            {
                string selected = (string)_propertyList.SelectedItem;
                _toModify = _terreni.Single(terreno => terreno.Nome == selected);
            }
            else
            {
                _currentStatusLabel.Text = "";
                _buildingValueLabel.Text = "";
                _questionLabel.Text = "";
                _okButton.Enabled = false;
                return;
            }
            if (_action == Action.BUILD)
            {
                if (_toModify.NumeroEdifici == 0)
                {
                    _currentStatusLabel.Text = "Su " + _toModify.Nome + " non sono attualmente costruiti edifici.";
                }
                else if (_toModify.NumeroEdifici == 1)
                {
                    _currentStatusLabel.Text = "Su " + _toModify.Nome + " è attualmente costruita " + _toModify.NumeroEdifici + " Casa.";
                }
                else
                {
                    _currentStatusLabel.Text = "Su " + _toModify.Nome + " sono attualmente costruite " + _toModify.NumeroEdifici + " Case.";
                }
                _buildingValueLabel.Text = "Il prezzo di costruzione di un edificio è " + _currency + _toModify.PrezzoCostruzioneEdificio;
                _questionLabel.Text = "Vuoi costruire un edificio?";
            }
            else if (_action == Action.DEMOLISH)
            {
                if (_toModify.NumeroEdifici == 1)
                {
                    _currentStatusLabel.Text = "Su " + _toModify.Nome + " è attualmente costruita " + _toModify.NumeroEdifici + " Casa.";
                }
                else if (_toModify.NumeroEdifici == 5)
                {
                    _currentStatusLabel.Text = "Su " + _toModify.Nome + " è attualmente costruito 1 Albergo.";
                }
                else
                {
                    _currentStatusLabel.Text = "Su " + _toModify.Nome + " sono attualmente costruite " + _toModify.NumeroEdifici + " Case.";
                }
                _buildingValueLabel.Text = "Demolendo un edificio la Banca pagherà una somma di " + _currency + _toModify.PrezzoCostruzioneEdificio / 2;
                _questionLabel.Text = "Vuoi demolire un edificio?";
            }
            _okButton.Enabled = true;
        }
    }
}
