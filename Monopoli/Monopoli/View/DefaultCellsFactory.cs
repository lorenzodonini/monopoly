using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.View
{
    class DefaultCellsFactory : ICellsFactory
    {
        public enum Position { BOTTOM = 0, LEFT = 1, TOP = 2, RIGHT = 3 };

        private int _rectCellWidth;
        private int _rectCellHeight;
        private Size _cellSize;
        private Point _location;
        private int _gamePanelLength;
        private int _cellNum;
        private static int _numCorners=4;
        private static decimal _cellRatio = 1.6m;
        private string _currency;
        private Position _side;

        public virtual Cell [] CreateViewCells(object [] cells, int gamePanelLength, string currency)
        {
            _cellNum = cells.Length;
            _gamePanelLength = gamePanelLength;
            _currency = currency;
            decimal divFactor = (_cellNum / _numCorners) - 1 + (_cellRatio * 2);
            _rectCellWidth = Decimal.ToInt32(_gamePanelLength / divFactor);
            _rectCellHeight = (_gamePanelLength - (_rectCellWidth * ((_cellNum / _numCorners) -1))) / 2;
            _cellSize = new System.Drawing.Size();
            _location = new System.Drawing.Point();
            Cell[] result = new Cell[cells.Length];
            int i = 0;
            foreach (Controller.DefaultConfigLoader.CellValue cell in cells)
            {
                result[i] = CreateViewCell(cell);
                i++;
            }
            return result;
        }

        protected virtual Cell CreateViewCell(Controller.DefaultConfigLoader.CellValue cell)
        {
            Cell result;
            List<object> args = new List<object>();
            args.Add(cell.Id);
            if (cell.Id < (_cellNum / _numCorners))
            {
                if (cell.Type == "Corner")
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
                    _side = Position.BOTTOM;
                }
            }
            else if (cell.Id < ((_cellNum / _numCorners) * 2))
            {
                if (cell.Type == "Corner")
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
                    _side = Position.LEFT;
                }
            }
            else if (cell.Id < ((_cellNum / _numCorners) * 3))
            {
                if (cell.Type == "Corner")
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
                    _side = Position.TOP;
                }
            }
            else if (cell.Id < _cellNum)
            {
                if (cell.Type == "Corner")
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
                    _side = Position.RIGHT;
                }
            }
            if(cell.Type != "Corner")
            {
                args.Add(_side);
            }
            args.Add(_cellSize);
            args.Add(_location);
            args.AddRange(cell.ToViewArguments());
            args.Add(_currency);
            Type type = Type.GetType("Monopoli.View."+cell.Type+"Cell");
            result = (Cell)Activator.CreateInstance(type, args.ToArray());
            return result;
        }
    }
}
