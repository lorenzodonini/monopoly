using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoli.View
{
    class CommonPropertyCell :Cell
    {
        private Panel _colorPanel = new Panel();
        private Label _nameLabel;
        private Label _valueLabel;

        public CommonPropertyCell(Position position, Size size, Point location, 
            int id, string name, decimal value, string group, string currency) 
            : base (size, location, id, currency)
        {
            _colorPanel.BackColor = Color.FromName(group);
            _nameLabel = new Label();
            _nameLabel.Text = name;
            this.Name = name;
            _valueLabel = new Label();
            _valueLabel.Text = currency +" "+ value.ToString();
            if (position == Position.LEFT)
            {
                Design90RotatedCell();
            }
            else if (position == Position.RIGHT)
            {
                Design270RotatedCell();
            }
            else if (position == Position.TOP)
            {
                Design180RotatedCell();
            }
            else
            {
                DesignDefaultCell();
            }
            _nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            _valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BackColor = Color.White;
            this.Controls.Add(_colorPanel);
            this.Controls.Add(_nameLabel);
            this.Controls.Add(_valueLabel);
            this.ResumeLayout();
        }

        #region Cell
        //Bottom side of the Board
        protected override void DesignDefaultCell()
        {
            _colorPanel.Size = new System.Drawing.Size(Size.Width, Size.Height / 5);
            _colorPanel.Location = new System.Drawing.Point(0, 0);
            _nameLabel.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5) * 3);
            _nameLabel.Location = new System.Drawing.Point(0, Size.Height / 5);
            _valueLabel.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5));
            _valueLabel.Location = new System.Drawing.Point(0, (Size.Height / 5) * 4);
        }

        //Left side of the Board
        protected override void Design90RotatedCell()
        {
            _colorPanel.Size = new System.Drawing.Size(Size.Width / 5, Size.Height);
            _colorPanel.Location = new System.Drawing.Point((Size.Width / 5) * 4, 0);
            _nameLabel.Size = new System.Drawing.Size((Size.Width / 5) * 4, Size.Height / 2);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _valueLabel.Size = new System.Drawing.Size((Size.Width / 5) * 4, Size.Height / 2);
            _valueLabel.Location = new System.Drawing.Point(0, Size.Height / 2);
        }

        //Top side of the Board
        protected override void Design180RotatedCell()
        {
            _colorPanel.Size = new System.Drawing.Size(Size.Width, Size.Height / 5);
            _colorPanel.Location = new System.Drawing.Point(0, (Size.Height / 5) * 4);
            _nameLabel.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5) * 3);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _valueLabel.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5));
            _valueLabel.Location = new System.Drawing.Point(0, (Size.Height / 5) * 3);
        }

        //Right side of the Board
        protected override void Design270RotatedCell()
        {
            _colorPanel.Size = new System.Drawing.Size(Size.Width / 5, Size.Height);
            _colorPanel.Location = new System.Drawing.Point(0, 0);
            _nameLabel.Size = new System.Drawing.Size((Size.Width / 5) * 4, Size.Height / 2);
            _nameLabel.Location = new System.Drawing.Point(Size.Width / 5, 0);
            _valueLabel.Size = new System.Drawing.Size((Size.Width / 5) * 4, Size.Height / 2);
            _valueLabel.Location = new System.Drawing.Point(Size.Width / 5, Size.Height / 2);
        }

        public override void resize(int width, int height)
        {
            throw new NotImplementedException();
        }
        #endregion

        public virtual void DrawBuilding(int buildingsNum)
        {
            Panel building;
            _colorPanel.Controls.Clear();
            if (buildingsNum == 0)
            {
                return;
            }
            else if (buildingsNum <= 4)
            {
                for (int i = 0; i < buildingsNum; i++)
                {
                    building = new Panel();
                    if ((Int32)this.Tag <= 10 || ((Int32)this.Tag >= 20 && (Int32)this.Tag <= 30))
                    {
                        building.Size = new Size(this.Width / 5, this.Width / 5);
                        building.BackColor = Color.DarkGreen;
                        building.Location = new Point(i * building.Width + (i+1) * building.Width / 5,
                            (_colorPanel.Height - building.Height) / 2);
                    }
                    else
                    {
                        building.Size = new Size(this.Height / 5, this.Height / 5);
                        building.BackColor = Color.DarkGreen;
                        building.Location = new Point((_colorPanel.Width - building.Width) / 2, i * building.Height + (i+1) * building.Height / 5);
                    }
                    _colorPanel.Controls.Add(building);
                }
            }
            else if (buildingsNum == 5)
            {
                building = new Panel();
                if ((Int32)this.Tag <= 10 || ((Int32)this.Tag >= 20 && (Int32)this.Tag <= 30))
                {
                    building.Size = new Size(this.Width / 5, this.Width / 5);
                    building.BackColor = Color.DarkRed;
                    _colorPanel.Controls.Clear();
                    building.Location = new Point((_colorPanel.Width - building.Width) / 2, (_colorPanel.Height - building.Height) / 2);
                }
                else
                {
                    building.Size = new Size(this.Height / 5, this.Height / 5);
                    building.BackColor = Color.DarkRed;
                    _colorPanel.Controls.Clear();
                    building.Location = new Point((_colorPanel.Width - building.Width) / 2, (_colorPanel.Height - building.Height) / 2);
                }
                _colorPanel.Controls.Add(building);
            }
            else
            {
                throw new InvalidOperationException("Number of buildings must be between 0 and 5");
            }
            _colorPanel.Invalidate();
        }
    }
}
