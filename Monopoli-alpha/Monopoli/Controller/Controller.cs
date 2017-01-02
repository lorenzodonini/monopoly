using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoli.Model;
using Monopoli.View;
using System.Windows.Forms;
using System.Reflection;

namespace Monopoli.Controller
{
    public class Controller
    {
        private MainView _mainView;
        private ICellsFactory _cellsFactory;
        private IConfigLoader _builder;
        private IDeedFactory _deedFactory;
        private string _currency;
        private GameController _gameController;

        public Controller(MainView mainView)
        {
            _mainView = mainView;
            //System.DateTime time = System.DateTime.Now;
            //string temp1 = time.Hour + ":" + time.Minute + ":" + time.Millisecond;

            //Caricamento dati Monopoli
            _builder = new DefaultConfigLoader();
            _builder.Load();

            //time = System.DateTime.Now;
            //string temp2 = time.Hour + ":" + time.Minute + ":" + time.Millisecond;
            //MessageBox.Show(temp1 + "\n" + temp2);
            _cellsFactory = new DefaultCellsFactory();
            _deedFactory = new DefaultDeedFactory(_builder.GetCurrencySymbol());
            _currency = _builder.GetCurrencySymbol();
        }

        //visualizzazione finestra per inserimento giocatori e invocazione metodi CreateGame e ViewGame
        public void NewGame_ButtonClicked()
        {
            NewGameDialog newGameDialog = new NewGameDialog(_builder.GetPlayerMaxNum(), _builder.GetPlayerMinNum(), 
                _builder.GetMarkers().Keys.ToArray());
            DialogResult dialogResult = newGameDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string [] names = newGameDialog.PlayerNames;
                string [] markers = newGameDialog.Markers;
                TimeSpan gameTime = newGameDialog.Duration;
                this.CreateGame(names, markers, gameTime);
            }
        }

        public void EndGame_ButtonClicked()
        {
            _gameController.TerminaPartita();
        }

        #region Game Creation
        //inizializzazione partita
        private void CreateGame(string[] names, string[] markers, TimeSpan gameTime)
        {
            //reperimento tavola da gioco
            TavolaDaGioco gameBoard = (TavolaDaGioco)_builder.GetPlayBoard();

            //creazione giocatori
            Giocatore [] players = CreatePlayers(names, markers, gameBoard.Caselle[0]);

            //creazione partita
            Partita partita = new Partita(players, gameBoard, gameTime);

            _gameController = new GameController(_currency);

            this.ViewGame(partita, gameBoard, gameTime);
        }
        
        //creazione giocatori
        private Giocatore [] CreatePlayers(string[] names, string[] markers, Casella startCell)
        {
            int numPlayers = names.Length;
            Giocatore[] players = new Giocatore[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                players[i] = new Giocatore(names[i], _builder.GetInitialMoneyValues()[numPlayers], markers[i], startCell);
            }
            return players;
        }

        //visualizzazione schermata di gioco
        private void ViewGame(Partita partita, TavolaDaGioco gameBoard, TimeSpan gameTime)
        {
            //System.DateTime time = System.DateTime.Now;
            //string temp1 = time.Hour + ":" + time.Minute + ":" + time.Millisecond;
            System.Drawing.Size mainPanelSize = _mainView.Size;
            //_boardPanel
            IGameBoard boardPanel = new GameBoard(partita, _builder.GetMarkers(), _builder.GetNumCells(), 
                new System.Drawing.Point(0, 0), new System.Drawing.Size(mainPanelSize.Height, mainPanelSize.Height), "_boardPanel");

            //creazione contratti
            Deed[] deedPool = _deedFactory.CreateDeeds(_builder.GetCells().ToArray());

            //_controlPanel
            ControlPanel controlPanel = new ControlPanel(new System.Drawing.Point(boardPanel.BoardSize.Width, (mainPanelSize.Height / 2)), 
                new System.Drawing.Size((mainPanelSize.Width - boardPanel.BoardSize.Width), (mainPanelSize.Height / 2)),
                 _gameController, partita, deedPool, _currency);

            //_gameInfoPanel
            GameInfoPanel gameInfoPanel = new GameInfoPanel(new System.Drawing.Point(0, 0), 
                new System.Drawing.Size((mainPanelSize.Width - boardPanel.BoardSize.Width), 
                    (mainPanelSize.Height / 2)), partita, _currency);

            //_userPanel
            UserPanel userPanel = new UserPanel(new System.Drawing.Point(boardPanel.BoardSize.Width, 0),
                new System.Drawing.Size((mainPanelSize.Width - boardPanel.BoardSize.Width), 
                mainPanelSize.Height), controlPanel, gameInfoPanel);

            CreateViewCells(boardPanel, gameBoard);
            //time = System.DateTime.Now;
            //string temp2 = time.Hour + ":" + time.Minute + ":" + time.Millisecond;
            //MessageBox.Show(temp1 + "\n" + temp2);

            DisplayInitialDeeds(deedPool, partita);
            _gameController.SetGame(partita, controlPanel);
            _mainView.SetGame(partita, boardPanel, userPanel);
        }

        private void CreateViewCells(IGameBoard boardPanel, TavolaDaGioco gameBoard)
        {
            Cell [] cells = _cellsFactory.CreateViewCells(gameBoard.Caselle, boardPanel.BoardSize, _currency);
            for (int i = 0; i < cells.Length; i++)
            {
                boardPanel.AddCell(i, cells[i]);
            }
        }
        #endregion

        private void DisplayInitialDeeds(Deed [] deedPool, Partita partita)
        {
            List<Deed> deeds = deedPool.ToList();
            Deed[] toShow;
            int i = 0;
            int initialDeeds = _builder.GetinitialDeeds()[partita.Giocatori.Length];
            decimal totalPayed;
            Terreno toBuy = null;
            InitialDeedsDialog dialog = new InitialDeedsDialog();
            ShuffleUtility.Shuffle(deeds);
            foreach (Giocatore player in partita.Giocatori)
            {
                i = 0;
                totalPayed = 0;
                toShow = new Deed[initialDeeds];
                while (i < initialDeeds)
                {
                    toBuy = (Terreno)partita.TavolaDaGioco.Caselle[deeds[0].ID];
                    totalPayed += toBuy.Valore;
                    player.AcquistaTerreno(toBuy);
                    toShow[i] = deeds[0];
                    deeds.RemoveAt(0);
                    i++;
                }
                dialog.SetName(player.Nome);
                dialog.SetTotalPayed(totalPayed, _currency);
                dialog.SetDeeds(toShow);
                dialog.SetNewMoney(player.Capitale, _currency);
                dialog.ShowDialog();
            }
        }
    }
}
