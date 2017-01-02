using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoli.View
{
    public partial class UserPanel : Panel
    {
        private ControlPanel _controlPanel;
        private GameInfoPanel _gameInfoPanel;

        public UserPanel(Point location, Size size, ControlPanel controlPanel, GameInfoPanel gameInfoPanel)
        {
            _controlPanel = controlPanel;
            _gameInfoPanel = gameInfoPanel;
            this.Size = size;
            this.Location = location;
            InitializeComponent();

            this.Controls.Add(_controlPanel);
            this.Controls.Add(_gameInfoPanel);

            _controlPanel.TerminaTurnoButton.Enabled = false;
            _controlPanel.PagaCauzioneButton.Enabled = false;
            _controlPanel.PagaButton.Enabled = false;
            _controlPanel.PagaTassaButton.Enabled = false;
            _controlPanel.PescaUnaCartaButton.Enabled = false;
            _controlPanel.PagaAffittoButton.Enabled = false;
            _controlPanel.AcquistaTerrenoButton.Enabled = false;
        }

        public UserPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void OnDispose()
        {
            _gameInfoPanel.Dispose();
            _controlPanel.OnDispose();
            this.Dispose();
        }
    }
}
