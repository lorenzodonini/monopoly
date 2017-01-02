using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Monopoli.View;
using Monopoli.Model;


namespace Monopoli
{
    public partial class MainView : Form
    {
        private Controller.Controller _controller;
        private ControlPanel _controlPanel;
        private GameBoard _gameBoardPanel;
        private Partita _partita;

        public MainView()
        {
            InitializeComponent();
            _controller = new Controller.Controller(this);
        }

        public void SetGame(Partita partita, GameBoard gameBoardPanel, ControlPanel controlPanel)
        {
            this.SuspendLayout();
            this.ActivePanel.Controls.Remove(_menuBar);
            this.Controls.Remove(ActivePanel);
            if (this.Controls.Contains(_gameBoardPanel))
            {
                this.Controls.Remove(_gameBoardPanel);
            }
            _gameBoardPanel = gameBoardPanel;
            _controlPanel = controlPanel;
            _menuBar.Dock = DockStyle.Right;
            _menuBar.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            _controlPanel.Controls.Add(_menuBar);
            _partita = partita;
            _partita.GameEnded += this.GameEnded;
            _gameBoardPanel.PutMarkersOnVia(partita.Giocatori);
            
            _controlPanel.TerminaTurnoButton.Enabled = false;
            _controlPanel.PagaCauzioneButton.Enabled = false;
            _controlPanel.PagaButton.Enabled = false;
            _controlPanel.PagaTassaButton.Enabled = false;
            _controlPanel.PescaUnaCartaButton.Enabled = false;
            _controlPanel.PagaAffittoButton.Enabled = false;
            _controlPanel.AcquistaTerrenoButton.Enabled = false;

            _toolStripEndGameItem.Enabled = true;
            this.Controls.Add(_gameBoardPanel);
            this.Controls.Add(_controlPanel);
            this.ResumeLayout();
        }

        public GameBoard GameBoardPanel
        {
            get { return _gameBoardPanel; }
        }

        public ControlPanel ControlPanel
        {
            get { return _controlPanel; }
        }

        public Panel ActivePanel
        {
            get
            {
                if(this.Controls.Contains(_welcomePanel))
                {
                    return _welcomePanel;
                }
                else if(this.Controls.Contains(_controlPanel))
                {
                    return _controlPanel;
                }
                return null;
            }
        }

        private void ToolStripExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripNewGameItem_Click(object sender, EventArgs e)
        {
            _controller.NewGame_ButtonClicked();
            if (ActivePanel == _controlPanel)
            {
                _toolStripNewGameItem.Enabled = false;
            }
        }

        private void ToolStripEndGameItem_Click(object sender, EventArgs e)
        {
            DialogResult res = WarningMessageBox.GetMessageBoxInstance().ShowDialogWithData("Terminando la partita verranno " + 
                "visualizzate le statistiche e non " + "si potrà più accedere alla partita in corso.", 
                "Vuoi davvero terminare la partita?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            _controller.EndGame_ButtonClicked();
            this.SuspendLayout();
            this.ControlPanel.Controls.Remove(_menuBar);
            this.Controls.Remove(_controlPanel);
            this.Controls.Remove(_gameBoardPanel);
            _menuBar.Dock = DockStyle.Top;
            _menuBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _welcomePanel.Controls.Add(_menuBar);
            this.Controls.Add(_welcomePanel);
            WarningMessageBox.GetMessageBoxInstance().Visible = false;
            _gameBoardPanel.Dispose();
            _controlPanel.OnDispose();
            _toolStripEndGameItem.Enabled = false;
            _toolStripNewGameItem.Enabled = true;
            this.ResumeLayout();
        }

        private void ToolStripRulesItem_Click(object sender, EventArgs e)
        {
            string projectBaseDir = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            System.Diagnostics.Process.Start(projectBaseDir + @"\Resources\regolamento.pdf");
        }

        private void GameEnded(object sender, EventArgs e)
        {
            EndGame();
        }
    }
}
