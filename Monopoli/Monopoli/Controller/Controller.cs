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
        private IConfigLoader _persister;
        private IDeedFactory _deedFactory;
        private string _currency;
        private GameController _gameController;

        public Controller(MainView mainView)
        {
            _mainView = mainView;
            //System.DateTime time = System.DateTime.Now;
            //string temp1 = time.Hour + ":" + time.Minute + ":" + time.Millisecond;
            _persister = new DefaultConfigLoader();
            _persister.Load();
            //time = System.DateTime.Now;
            //string temp2 = time.Hour + ":" + time.Minute + ":" + time.Millisecond;
            //MessageBox.Show(temp1 + "\n" + temp2);
            _cellsFactory = new DefaultCellsFactory();
            _deedFactory = new DefaultDeedFactory(_persister.GetCurrencySymbol());
            _currency = _persister.GetCurrencySymbol();
        }

        //visualizzazione finestra per inserimento giocatori e invocazione metodi CreateGame e ViewGame
        public void NewGame_ButtonClicked()
        {
            NewGameDialog newGameDialog = new NewGameDialog(_persister.GetPlayerMaxNum(), _persister.GetPlayerMinNum(), 
                _persister.GetMarkers().Keys.ToArray());
            DialogResult dialogResult = newGameDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string [] names = newGameDialog.GetPlayerNames;
                string [] markers = newGameDialog.GetMarkers;
                TimeSpan gameTime = newGameDialog.GetDuration;
                this.CreateGame(names, markers, gameTime);
            }
        }

        public void EndGame_ButtonClicked()
        {
            _gameController.TerminaPartita();
        }

        //inizializzazione partita
        private void CreateGame(string[] names, string[] markers, TimeSpan gameTime)
        {
            //creazione caselle
            Casella[] cells = CreateModelCells();

            //creazione giocatori
            Giocatore [] players = CreatePlayers(names, markers, cells[0]);

            //creazione carte
            Carta[] chance = CreateChanceCards();
            Carta[] communityChest = CreateCommunityChestCards();
           
            //creazione tavola da gioco
            TavolaDaGioco gameBoard = new TavolaDaGioco(cells, communityChest, chance);

            _gameController = new GameController(_currency);

            this.ViewGame(players, gameBoard, gameTime);
        }

        private Casella [] CreateModelCells()
        {
            int i = 0;
            Casella [] cells = new Casella[_persister.GetNumCells()];
            DefaultConfigLoader.CellValue [] vals = (DefaultConfigLoader.CellValue [])_persister.GetCells();
            foreach (DefaultConfigLoader.CellValue val in vals)
            {
                Type type = Type.GetType("Monopoli.Model." + val.Model);
                object[] args = val.ToModelArguments();
                cells[i++] = (Casella)Activator.CreateInstance(type, args);
            }
            return cells;
        }

        //carte probabilità
        private Carta[] CreateChanceCards()
        {
            List<Carta> chance = new List<Carta>();
            foreach (DefaultConfigLoader.CardValue card in _persister.GetCards())
            {
                if (card.Type == "Probabilità")
                {
                    Type type = Type.GetType("Monopoli.Model.Carta+" + card.Action);
                    List<object> args = new List<object>();
                    args.Add(Carta.TipoCarta.PROBABILITA);
                    args.AddRange(card.ToModelArguments());
                    chance.Add((Carta)Activator.CreateInstance(type, args.ToArray()));
                }
            }
            return chance.ToArray();
        }

        //carte imprevisti
        private Carta[] CreateCommunityChestCards()
        {
            List<Carta> communityChest = new List<Carta>();
            foreach (DefaultConfigLoader.CardValue card in _persister.GetCards())
            {
                if (card.Type == "Imprevisti")
                {
                    Type type = Type.GetType("Monopoli.Model.Carta+" + card.Action);
                    List<object> args = new List<object>();
                    args.Add(Carta.TipoCarta.IMPREVISTI);
                    args.AddRange(card.ToModelArguments());
                    communityChest.Add((Carta)Activator.CreateInstance(type, args.ToArray()));
                }
            }
            return communityChest.ToArray();
        }
        
        //creazione giocatori
        private Giocatore [] CreatePlayers(string[] names, string[] markers, Casella startCell)
        {
            int numPlayers = names.Length;
            Giocatore[] players = new Giocatore[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                players[i] = new Giocatore(names[i], _persister.GetInitialMoneyValues()[numPlayers], markers[i], startCell);
            }
            return players;
        }

        //visualizzazione schermata di gioco
        private void ViewGame(Giocatore [] players, TavolaDaGioco gameBoard, TimeSpan gameTime)
        {
            System.Drawing.Size mainPanelSize = _mainView.Size;
            Partita partita = new Partita(players, gameBoard, gameTime);
            //_boardPanel
            GameBoard boardPanel = new GameBoard(partita, _persister.GetMarkers(), _persister.GetNumCells(), 
                new System.Drawing.Point(0, 0), new System.Drawing.Size(mainPanelSize.Height, mainPanelSize.Height), "_boardPanel");


            //creazione contratti
            Deed[] deedPool = _deedFactory.CreateDeeds(_persister.GetCells());

            //_controlPanel
            ControlPanel controlPanel = new ControlPanel(new System.Drawing.Point(boardPanel.Width, 0), 
                new System.Drawing.Size((mainPanelSize.Width - boardPanel.Size.Width), mainPanelSize.Height),
                "_controlPanel", _gameController, partita, deedPool, _currency);

            CreateViewCells(boardPanel);

            DisplayInitialDeeds(deedPool, partita);
            _gameController.SetGame(partita, controlPanel);
            _mainView.SetGame(partita, boardPanel, controlPanel);
        }

        private void CreateViewCells(GameBoard boardPanel)
        {
            Cell [] cells = _cellsFactory.CreateViewCells((DefaultConfigLoader.CellValue [])_persister.GetCells(), boardPanel.Height, _currency);
            for (int i = 0; i < cells.Length; i++)
            {
                boardPanel.AddCell(i, cells[i]);
            }
        }

        private void DisplayInitialDeeds(Deed [] deedPool, Partita partita)
        {
            List<Deed> deeds = deedPool.ToList();
            Deed[] toShow;
            int i = 0;
            int initialDeeds = _persister.GetinitialDeeds()[partita.Giocatori.Length];
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
