using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoli.View
{
    public class NewGameDialog : Form
    {
        #region Variables

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel _playerInfoPanel;
        private System.Windows.Forms.Label _playerNameLabel;
        private System.Windows.Forms.Label _playerMarkerLabel;
        private System.Windows.Forms.TextBox[] _playerNames;
        private System.Windows.Forms.ComboBox[] _playerMarkers;
        private System.Windows.Forms.CheckBox _durationCheckBox;
        private readonly int _maxPlayers;
        private readonly int _minPlayers;
        private readonly string [] _markers;
        private static string _nullComboItem = "<-- Nessuna Selezione -->";
        private static string _wrongPlayerName = "Nome Giocatore invalido o già presente!";
        private static string _notInsertedPlayerName = "Nome del Giocatore non inserito!";
        private static string _notInsertedPlayerMarker = "Segnalino non selezionato!";
        private System.Windows.Forms.Label _descriptionLabel1;
        private System.Windows.Forms.NumericUpDown _hoursUpDown;
        private System.Windows.Forms.Label _hoursLabel;
        private System.Windows.Forms.Label _minutesLabel;
        private System.Windows.Forms.NumericUpDown _minutesUpDown;
        private System.Windows.Forms.Label _mainLabel;
        private System.Windows.Forms.ErrorProvider _playerInfoError;
        private System.Windows.Forms.Label _descriptionLabel2;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _createButton;

        #endregion

        public NewGameDialog(int maxPlayers, int minPlayers, string[] markers)
        {
            _maxPlayers = maxPlayers;
            _minPlayers = minPlayers;
            _markers = markers;
            InitializeComponent();
        }

        #region Properties
        public string [] PlayerNames
        {
            get {
                List<string> names = new List<string>();
                for (int i = 0; i < _maxPlayers; i++)
                {
                    if (!String.IsNullOrEmpty(_playerNames[i].Text) && _playerMarkers[i].SelectedItem!=null)
                    {
                        names.Add(_playerNames[i].Text);
                    }
                }
                return names.ToArray();
            }
        }

        public string[] Markers
        {
            get {
                List<string> markers = new List<string>();
                for(int i=0; i< _maxPlayers;i++)
                {
                    if (!String.IsNullOrEmpty(_playerNames[i].Text) && _playerMarkers[i].SelectedItem != null)
                    {
                        markers.Add(_playerMarkers[i].SelectedItem.ToString());
                    }
                }
                return markers.ToArray();
            }
        }

        public TimeSpan Duration
        {
            get
            {
                if (_durationCheckBox.Checked)
                    return new TimeSpan (0);
                return new TimeSpan((Int32)_hoursUpDown.Value, (Int32)_minutesUpDown.Value, 0);
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component init
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._playerInfoPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._playerNames = new System.Windows.Forms.TextBox[_maxPlayers];
            this._playerMarkers = new System.Windows.Forms.ComboBox[_maxPlayers];
            int i = 0;
            for (i = 0; i < _maxPlayers; i++)
            {
                this._playerNames[i] = new System.Windows.Forms.TextBox();
                this._playerMarkers[i] = new System.Windows.Forms.ComboBox();
            }
            this._playerNameLabel = new System.Windows.Forms.Label();
            this._playerMarkerLabel = new System.Windows.Forms.Label();
            this._descriptionLabel1 = new System.Windows.Forms.Label();
            this._hoursUpDown = new System.Windows.Forms.NumericUpDown();
            this._hoursLabel = new System.Windows.Forms.Label();
            this._minutesLabel = new System.Windows.Forms.Label();
            this._minutesUpDown = new System.Windows.Forms.NumericUpDown();
            this._mainLabel = new System.Windows.Forms.Label();
            this._playerInfoError = new System.Windows.Forms.ErrorProvider(this.components);
            this._descriptionLabel2 = new System.Windows.Forms.Label();
            this._createButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._durationCheckBox = new System.Windows.Forms.CheckBox();
            this._playerInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._hoursUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._minutesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._playerInfoError)).BeginInit();
            this.SuspendLayout();
            // 
            // _playerInfoPanel
            // 
            for (i = 0; i < _maxPlayers; i++)
            {
                this._playerInfoPanel.Controls.Add(this._playerNames[i]);
                this._playerInfoPanel.Controls.Add(this._playerMarkers[i]);
            }
            this._playerInfoPanel.Location = new System.Drawing.Point(5, 190);
            this._playerInfoPanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._playerInfoPanel.Name = "_playerInfoPanel";
            this._playerInfoPanel.Size = new System.Drawing.Size(504, 193);
            this._playerInfoPanel.AutoScroll = true;
            this._playerInfoPanel.TabIndex = 1;
            // 
            // _playerNames and _playerMarkers
            // 
            for (i = 0; i < _maxPlayers; i++)
            {
                if (i == 0)
                {
                    this._playerNames[i].Location = new System.Drawing.Point(3, 5);
                    this._playerMarkers[i].Location = new System.Drawing.Point(309, 5);
                }
                else
                {
                    this._playerNames[i].Location = new System.Drawing.Point(3, (this._playerNames[i - 1].Location.Y + this._playerNames[i - 1].Size.Height
                        + this._playerNames[i - 1].Margin.Bottom + this._playerNames[i - 1].Margin.Top));
                    this._playerMarkers[i].Location = new System.Drawing.Point(309, (this._playerMarkers[i - 1].Location.Y + this._playerMarkers[i - 1].Size.Height +
                        this._playerMarkers[i - 1].Margin.Bottom + this._playerMarkers[i - 1].Margin.Top));
                }
                this._playerNames[i].Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
                this._playerNames[i].Name = "playerName" + i;
                this._playerNames[i].Size = new System.Drawing.Size(300, 22);
                this._playerNames[i].KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlayerName_KeyUp);
                this._playerNames[i].TabIndex = i * 2;

                this._playerMarkers[i].FormattingEnabled = true;
                this._playerMarkers[i].Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
                this._playerMarkers[i].Name = "playerMarker" + i;
                this._playerMarkers[i].Size = new System.Drawing.Size(165, 22);
                this._playerMarkers[i].TabIndex = (i * 2) + 1;
                this._playerMarkers[i].DropDownStyle = ComboBoxStyle.DropDownList;
                this._playerMarkers[i].SelectedIndexChanged+= new EventHandler(this.PlayerMarker_Change);
                this._playerMarkers[i].Items.Add(_nullComboItem);
                this._playerMarkers[i].Items.AddRange(_markers);
            }
            // 
            // _playerNameLabel
            // 
            this._playerNameLabel.AutoSize = true;
            this._playerNameLabel.Location = new System.Drawing.Point(9, 166);
            this._playerNameLabel.Name = "_playerNameLabel";
            this._playerNameLabel.Size = new System.Drawing.Size(95, 14);
            this._playerNameLabel.TabIndex = 2;
            this._playerNameLabel.Text = "Nome Giocatore";
            // 
            // _playerMarkerLabel
            // 
            this._playerMarkerLabel.AutoSize = true;
            this._playerMarkerLabel.Location = new System.Drawing.Point(319, 166);
            this._playerMarkerLabel.Name = "_playerMarkerLabel";
            this._playerMarkerLabel.Size = new System.Drawing.Size(59, 14);
            this._playerMarkerLabel.TabIndex = 3;
            this._playerMarkerLabel.Text = "Segnalino";
            // 
            // _descriptionLabel1
            // 
            this._descriptionLabel1.AutoSize = true;
            this._descriptionLabel1.Location = new System.Drawing.Point(9, 58);
            this._descriptionLabel1.Name = "_descriptionLabel1";
            this._descriptionLabel1.Size = new System.Drawing.Size(232, 14);
            this._descriptionLabel1.TabIndex = 4;
            this._descriptionLabel1.Text = "Impostare la durata massima della Partita:";
            // 
            // _hoursUpDown
            // 
            this._hoursUpDown.Location = new System.Drawing.Point(47, 83);
            this._hoursUpDown.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._hoursUpDown.Maximum = new decimal(new int[] {23, 0, 0, 0});
            this._hoursUpDown.Name = "_hoursUpDown";
            this._hoursUpDown.Size = new System.Drawing.Size(97, 22);
            this._hoursUpDown.TabIndex = 5;
            // 
            // _hoursLabel
            // 
            this._hoursLabel.AutoSize = true;
            this._hoursLabel.Location = new System.Drawing.Point(9, 85);
            this._hoursLabel.Name = "_hoursLabel";
            this._hoursLabel.Size = new System.Drawing.Size(31, 14);
            this._hoursLabel.TabIndex = 6;
            this._hoursLabel.Text = "Ore:";
            // 
            // _minutesLabel
            // 
            this._minutesLabel.AutoSize = true;
            this._minutesLabel.Location = new System.Drawing.Point(168, 85);
            this._minutesLabel.Name = "_minutesLabel";
            this._minutesLabel.Size = new System.Drawing.Size(43, 14);
            this._minutesLabel.TabIndex = 7;
            this._minutesLabel.Text = "Minuti:";
            // 
            // _minutesUpDown
            // 
            this._minutesUpDown.Location = new System.Drawing.Point(217, 83);
            this._minutesUpDown.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this._minutesUpDown.Maximum = new decimal(new int[] {59, 0, 0, 0});
            this._minutesUpDown.Name = "_minutesUpDown";
            this._minutesUpDown.Size = new System.Drawing.Size(97, 22);
            this._minutesUpDown.TabIndex = 8;
            // 
            // _mainLabel
            // 
            this._mainLabel.AutoSize = true;
            this._mainLabel.Font = new System.Drawing.Font("Tahoma", 14F);
            this._mainLabel.Location = new System.Drawing.Point(8, 9);
            this._mainLabel.Name = "_mainLabel";
            this._mainLabel.Size = new System.Drawing.Size(222, 23);
            this._mainLabel.TabIndex = 9;
            this._mainLabel.Text = "Preparazione della Partita";
            // 
            // _playerInfoError
            // 
            this._playerInfoError.ContainerControl = this;
            this._playerInfoError.SetError(this._createButton, "Devono essere presenti almeno " + _minPlayers + " Giocatori!");
            // 
            // _descriptionLabel2
            // 
            this._descriptionLabel2.AutoSize = true;
            this._descriptionLabel2.Location = new System.Drawing.Point(9, 139);
            this._descriptionLabel2.Name = "_descriptionLabel2";
            this._descriptionLabel2.Size = new System.Drawing.Size(152, 14);
            this._descriptionLabel2.TabIndex = 10;
            this._descriptionLabel2.Text = "Inserire i dati dei Giocatori:";
            // 
            // _createButton
            // 
            this._createButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._createButton.Location = new System.Drawing.Point(152, 403);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(87, 23);
            this._createButton.TabIndex = 11;
            this._createButton.Text = "Crea Partita";
            this._createButton.Enabled = false;
            this._createButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(264, 403);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(87, 23);
            this._cancelButton.TabIndex = 12;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _durationCheckBox
            // 
            this._durationCheckBox.Location = new System.Drawing.Point(349, 77);
            this._durationCheckBox.Name = "checkBox1";
            this._durationCheckBox.Size = new System.Drawing.Size(160, 32);
            this._durationCheckBox.CheckedChanged += new EventHandler(DurationSetting_CheckedChanged);
            this._durationCheckBox.TabIndex = 13;
            this._durationCheckBox.Text = "Non impostare la durata massima della Partita";
            this._durationCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewGameDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(521, 442);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._createButton);
            this.Controls.Add(this._durationCheckBox);
            this.Controls.Add(this._descriptionLabel2);
            this.Controls.Add(this._mainLabel);
            this.Controls.Add(this._minutesUpDown);
            this.Controls.Add(this._minutesLabel);
            this.Controls.Add(this._hoursLabel);
            this.Controls.Add(this._hoursUpDown);
            this.Controls.Add(this._descriptionLabel1);
            this.Controls.Add(this._playerNameLabel);
            this.Controls.Add(this._playerMarkerLabel);
            this.Controls.Add(this._playerInfoPanel);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGameDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuova Partita";
            this.TopMost = true;
            this._playerInfoPanel.ResumeLayout(false);
            this._playerInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._hoursUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._minutesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._playerInfoError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Input validation
        private void PlayerName_KeyUp(object sender, EventArgs e)
        {
            TextBox validating = (TextBox)sender;
            int i = 0;
            int position = -1;
            for (i = 0; i < _playerNames.Length; i++)
            {
                if(validating.Equals(_playerNames[i]))
                {
                    position = i;
                    break;
                }
            }
            _playerInfoError.SetError(_playerMarkers[position], null);
            if (!String.IsNullOrEmpty(validating.Text))
            {
                Check_NameUniqueness(validating, position);
            }
            IsValidData();
        }

        private void Check_NameUniqueness(TextBox validating, int position)
        {
            foreach (TextBox player in _playerNames)
            {
                if (validating != player && validating.Text == player.Text)
                {
                    _playerInfoError.SetError(_playerMarkers[position], _wrongPlayerName);
                    break;
                }
            }
        }

        private void IsValidData()
        {
            if (!MinPlayersInserted())
            {
                _createButton.Enabled = false;
                _playerInfoError.SetError(this._createButton, "Devono essere presenti almeno " + _minPlayers + " Giocatori inseriti correttamente!");
            }
            else
            {
                for (int i = 0; i < _playerMarkers.Length; i++)
                {
                    if (!String.IsNullOrEmpty(_playerInfoError.GetError(_playerMarkers[i])))
                    {
                        _createButton.Enabled = false;
                        _playerInfoError.SetError(this._createButton, "I Giocatori devono essere inseriti correttamente!");
                        return;
                    }
                }
                _createButton.Enabled = true;
                this._playerInfoError.SetError(this._createButton, null);
            }
        }

        //Validation of number of inserted Players
        private bool MinPlayersInserted()
        {
            int count = 0;
            for (int i = 0; i < _playerNames.Length; i++)
            {
                if (String.IsNullOrEmpty(_playerNames[i].Text) && _playerMarkers[i].SelectedItem != null && (String)_playerMarkers[i].SelectedItem != _nullComboItem)
                {
                    if (String.IsNullOrEmpty(_playerInfoError.GetError(_playerMarkers[i])))
                    {
                        _playerInfoError.SetError(_playerMarkers[i], _notInsertedPlayerName);
                    }
                }
                else if (!String.IsNullOrEmpty(_playerNames[i].Text) && (_playerMarkers[i].SelectedItem == null || (String)_playerMarkers[i].SelectedItem == _nullComboItem))
                {
                    if (String.IsNullOrEmpty(_playerInfoError.GetError(_playerMarkers[i])))
                    {
                        _playerInfoError.SetError(_playerMarkers[i], _notInsertedPlayerMarker);
                    }
                }
                else if (!String.IsNullOrEmpty(_playerNames[i].Text) && _playerMarkers[i].SelectedItem != null 
                    && (String)_playerMarkers[i].SelectedItem!= _nullComboItem)
                {
                    count++;
                }
            }
            return (count >= _minPlayers);
        }

        //Validation of ComboBox selection
        private void PlayerMarker_Change(object sender, EventArgs e)
        {
            ComboBox changed = (ComboBox)sender;
            for (int i = 0; i < _playerMarkers.Length; i++)
            {
                
                if (_playerMarkers[i] != changed)
                {
                    foreach (object item in changed.Items)
                    {
                        if (!_playerMarkers[i].Items.Contains(item) && item != changed.SelectedItem)
                        {
                            _playerMarkers[i].Items.Insert(changed.Items.IndexOf(item), item);
                        }
                    }
                    if (changed.SelectedItem != null && (String)changed.SelectedItem != _nullComboItem)
                    {
                        _playerMarkers[i].Items.Remove(changed.SelectedItem);
                    }
                }
            }
            if (_playerInfoError.GetError(changed) != _wrongPlayerName)
            {
                _playerInfoError.SetError(changed, null);
            }
            IsValidData();
        }

        private void DurationSetting_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox changed = (CheckBox)sender;
            if (changed.Checked)
            {
                _minutesUpDown.Enabled = false;
                _hoursUpDown.Enabled = false;
            }
            else
            {
                _minutesUpDown.Enabled = true;
                _hoursUpDown.Enabled = true;
            }
        }
        #endregion
    }
}
