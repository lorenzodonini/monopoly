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
        private IGameBoard _gameBoardPanel;
        private UserPanel _userPanel;
        private Partita _partita;

        public MainView()
        {
            InitializeComponent();
            _controller = new Controller.Controller(this);
        }

        public void SetGame(Partita partita, IGameBoard gameBoardPanel, UserPanel userPanel)
        {
            this.SuspendLayout();
            this.ActivePanel.Controls.Remove(_menuBar);
            this.Controls.Remove(ActivePanel);
            if (this.Controls.Contains((GameBoard)_gameBoardPanel))
            {
                this.Controls.Remove((GameBoard)_gameBoardPanel);
            }
            _userPanel = userPanel;
            _gameBoardPanel = gameBoardPanel;
            _menuBar.Dock = DockStyle.Right;
            _menuBar.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            _userPanel.Controls.Add(_menuBar);
            _partita = partita;
            _partita.GameEnded += this.GameEnded;
            _gameBoardPanel.PutMarkersOnStartCell(partita.Giocatori);

            _toolStripEndGameItem.Enabled = true;
            this.Controls.Add(_userPanel);
            this.Controls.Add((GameBoard)_gameBoardPanel);
            this.Controls.Add(_userPanel);
            this.ResumeLayout();
        }

        public Panel ActivePanel
        {
            get
            {
                if(this.Controls.Contains(_welcomePanel))
                {
                    return _welcomePanel;
                }
                else if(this.Controls.Contains(_userPanel))
                {
                    return _userPanel;
                }
                return null;
            }
        }

        public void EndGame()
        {
            _controller.EndGame_ButtonClicked();
            this.SuspendLayout();
            this._userPanel.Controls.Remove(_menuBar);
            this.Controls.Remove(_userPanel);
            this.Controls.Remove((GameBoard)_gameBoardPanel);
            _menuBar.Dock = DockStyle.Top;
            _menuBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _welcomePanel.Controls.Add(_menuBar);
            this.Controls.Add(_welcomePanel);
            WarningMessageBox.GetMessageBoxInstance().Visible = false;
            _gameBoardPanel.DisposeGameBoard();
            _userPanel.OnDispose();
            _toolStripEndGameItem.Enabled = false;
            _toolStripNewGameItem.Enabled = true;
            this.ResumeLayout();
        }

        #region GUI EventHandlers
        private void ToolStripRulesItem_Click(object sender, EventArgs e)
        {
            string projectBaseDir = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            System.Diagnostics.Process.Start(projectBaseDir + @"\Resources\regolamento.pdf");
        }

        private void ToolStripExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripNewGameItem_Click(object sender, EventArgs e)
        {
            _controller.NewGame_ButtonClicked();
            if (ActivePanel == _userPanel)
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
        #endregion

        #region Model EventHandlers
        private void GameEnded(object sender, EventArgs e)
        {
            EndGame();
        }
        #endregion
    }
}
