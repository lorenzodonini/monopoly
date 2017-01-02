using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Monopoli.Model;
using System.Reflection;

namespace Monopoli.View
{
    class DefaultCellsFactory : ICellsFactory
    {
        private int _rectCellWidth;
        private int _rectCellHeight;
        private Size _cellSize;
        private Point _location;
        private int _gamePanelLength;
        private int _cellNum;
        private static int _numCorners=4;
        private static decimal _cellRatio = 1.6m;
        private string _currency;
        private Cell.Position _side;

        #region ICellsFactory
        public virtual Cell [] CreateViewCells(object [] cells, Size gamePanelSize, string currency)
        {
            _cellNum = cells.Length;
            _gamePanelLength = gamePanelSize.Height;
            _currency = currency;
            decimal divFactor = (_cellNum / _numCorners) - 1 + (_cellRatio * 2);
            _rectCellWidth = Decimal.ToInt32(_gamePanelLength / divFactor);
            _rectCellHeight = (_gamePanelLength - (_rectCellWidth * ((_cellNum / _numCorners) -1))) / 2;
            _cellSize = new System.Drawing.Size();
            _location = new System.Drawing.Point();
            Cell[] result = new Cell[cells.Length];
            int i = 0;
            foreach (Casella cell in cells)
            {
                result[i] = CreateViewCell(cell);
                i++;
            }
            return result;
        }
        #endregion

        protected virtual Cell CreateViewCell(Casella cell)
        {
            Cell result;
            List<object> args = new List<object>();
            if (cell.ID < (_cellNum / _numCorners))
            {
                if ((cell.ID % 10) == 0)
                {
                    _cellSize.Width = _rectCellHeight;
                    _cellSize.Height = _rectCellHeight;
                    _location.X = _gamePanelLength - _cellSize.Width;
                    _location.Y = _gamePanelLength - _cellSize.Height;
                }
                else
                {
                    _cellSize.Width = _rectCellWidth;
                    _location.X = _location.X - _cellSize.Width;
                    _side = Cell.Position.BOTTOM;
                }
            }
            else if (cell.ID < ((_cellNum / _numCorners) * 2))
            {
                if ((cell.ID % 10) == 0)
                {
                    _cellSize.Width = _rectCellHeight;
                    _cellSize.Height = _rectCellHeight;
                    _location.X = 0;
                    _location.Y = _gamePanelLength - _cellSize.Height;
                }
                else
                {
                    _cellSize.Height = _rectCellWidth;
                    _location.Y = _location.Y - _cellSize.Height;
                    _side = Cell.Position.LEFT;
                }
            }
            else if (cell.ID < ((_cellNum / _numCorners) * 3))
            {
                if ((cell.ID % 10) == 0)
                {
                    _cellSize.Width = _rectCellHeight;
                    _cellSize.Height = _rectCellHeight;
                    _location.X = 0;
                    _location.Y = 0;
                }
                else
                {
                    _location.X = _location.X + _cellSize.Width;
                    _cellSize.Width = _rectCellWidth;
                    _side = Cell.Position.TOP;
                }
            }
            else if (cell.ID < _cellNum)
            {
                if ((cell.ID % 10) == 0)
                {
                    _cellSize.Width = _rectCellHeight;
                    _cellSize.Height = _rectCellHeight;
                    _location.X = _gamePanelLength - _cellSize.Width;
                    _location.Y = 0;
                }
                else
                {
                    _location.Y = _location.Y + _cellSize.Height;
                    _cellSize.Height = _rectCellWidth;
                    _side = Cell.Position.RIGHT;
                }
            }
            if ((cell.ID % 10) != 0)
            {
                args.Add(_side);
            }
            args.Add(_cellSize);
            args.Add(_location);
            args.AddRange(cell.GetParametriCella());
            args.Add(_currency);
            Type type = Type.GetType("Monopoli.View."+cell.TipoCella+"Cell");
            result = (Cell)Activator.CreateInstance(type, args.ToArray());
            return result;
        }
    }
}
