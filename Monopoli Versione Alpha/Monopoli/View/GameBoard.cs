using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    public class GameBoard : Panel, IGameBoard
    {
        private Cell[] _cells;
        private Dictionary<string, PictureBox> _markers = new Dictionary<string, PictureBox>();

        public GameBoard(Monopoli.Model.Partita partita, Dictionary<string, Image> markers, int cellNum, Point location, Size size, string name)
        {
            _cells = new Cell[cellNum];
            foreach (String marker in markers.Keys)
            {
                PictureBox p = new PictureBox();
                p.Image = markers[marker];
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.BackColor = Color.Transparent;
                _markers.Add(marker, p);
            }
            this.Location = location;
            this.Size = size;
            this.Name = name;
            this.BackColor = Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(231)))), ((int)(((byte)(206)))));
            this.BackgroundImage = Monopoli.Properties.Resources.background;
            this.BackgroundImageLayout = ImageLayout.Zoom;

            foreach (Monopoli.Model.Giocatore player in partita.Giocatori)
            {
                player.PositionChanged += RefreshPosition;
                player.PlayerQuit += DeleteMarker;
            }
            foreach (Monopoli.Model.Casella cell in partita.TavolaDaGioco.Caselle)
            {
                if (cell is Monopoli.Model.TerrenoNormale)
                {
                    Monopoli.Model.TerrenoNormale terreno = (Monopoli.Model.TerrenoNormale)cell;
                    terreno.BuildingChanged += RefreshBuildings;
                }
            }
        }

        #region IGameBoard
        public Control[] Cells
        {
            get { return _cells; }
        }

        public Control[] Markers
        {
            get { return _markers.Values.ToArray(); }
        }

        public void AddCell(int index, Control cell)
        {
            _cells[index] = (Cell)cell;
            index++;
            this.Controls.Add(cell);
        }

        public void RemoveCell(int index, Control cell)
        {
            _cells[index] = (Cell)cell;
            this.Controls.Remove(cell);
        }

        private void DeleteMarker(object sender, EventArgs e)
        {
            Monopoli.Model.Giocatore g = (Monopoli.Model.Giocatore)sender;
            _markers[g.Segnalino].Visible = false;
        }

        public void PutMarkersOnStartCell(object[] players)
        {
            foreach (Monopoli.Model.Giocatore player in players)
            {
                this.RefreshPosition(player, EventArgs.Empty);
            }
        }

        public void PutMarker(Control marker)
        {
        }

        public void RemoveMarker(Control marker)
        {
        }

        public Size BoardSize 
        {
            get { return Size; } 
        }

        public Point BoardLocation 
        {
            get { return Location; } 
        }

        public void DisposeGameBoard()
        {
            base.Dispose();
        }
        #endregion

        #region RefreshHandlers
        private void RefreshPosition(object sender, EventArgs e)
        {
            Monopoli.Model.Giocatore giocatore = (Monopoli.Model.Giocatore)sender;
            foreach (Cell cell in _cells)
            {
                if ((Int32)cell.Tag == giocatore.PosizioneCorrente.ID)
                {
                    cell.DrawMarker(_markers[giocatore.Segnalino]);
                    break;
                }
            }
        }

        private void RefreshBuildings(object sender, EventArgs e)
        {
            Monopoli.Model.TerrenoNormale terreno = (Monopoli.Model.TerrenoNormale)sender;
            foreach (Cell cell in _cells)
            {
                if ((Int32)cell.Tag == terreno.ID)
                {
                    ((CommonPropertyCell)cell).DrawBuilding(terreno.NumeroEdifici);
                    break;
                }
            }
        }
        #endregion
    }
}
