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

        public CommonPropertyCell(int id, Monopoli.View.DefaultCellsFactory.Position position, Size size, Point location, 
            string name, decimal value, string group, string currency) 
            : base (id, size, location, currency)
        {
            _colorPanel.BackColor = Color.FromName(group);
            _nameLabel = new Label();
            _nameLabel.Text = name;
            this.Name = name;
            _valueLabel = new Label();
            _valueLabel.Text = currency +" "+ value.ToString();
            if (position == DefaultCellsFactory.Position.LEFT)
            {
                Design90RotatedCell();
            }
            else if (position == DefaultCellsFactory.Position.RIGHT)
            {
                Design270RotatedCell();
            }
            else if (position == DefaultCellsFactory.Position.TOP)
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

        public override void resize(int width)
        {
            this.Width = width;
            this.Height = (Int32)(ratio * width);
        }

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

        public void DrawBuilding(int buildingsNum)
        {
            Panel coloredPanel = (Panel)this.Controls.OfType<Panel>().ToArray()[0];
            if (buildingsNum == 0)
            {
                coloredPanel.Controls.Clear();
                return;
            }
            Panel building = new Panel();
            if ((Int32)this.Tag <= 10 || ((Int32)this.Tag >= 20 && (Int32)this.Tag <= 30))
            {
                building.Size = new Size(this.Width / 5, this.Width / 5);
                if (buildingsNum <= 4)
                {
                    building.BackColor = Color.DarkGreen;
                    building.Location = new Point((buildingsNum - 1) * building.Width + buildingsNum * building.Width / 5,
                        (coloredPanel.Height - building.Height) / 2);
                }
                else if (buildingsNum == 5)
                {
                    building.BackColor = Color.DarkRed;
                    coloredPanel.Controls.Clear();
                    building.Location = new Point((coloredPanel.Width - building.Width) / 2, (coloredPanel.Height - building.Height) / 2);
                }
            }
            else
            {
                building.Size = new Size(this.Height / 5, this.Height / 5);
                if (buildingsNum <= 4)
                {
                    building.BackColor = Color.DarkGreen;
                    building.Location = new Point((coloredPanel.Width - building.Width) / 2, (buildingsNum - 1) * building.Height + buildingsNum * building.Height / 5);
                }
                else if (buildingsNum == 5)
                {
                    building.BackColor = Color.DarkRed;
                    coloredPanel.Controls.Clear();
                    building.Location = new Point((coloredPanel.Width - building.Width) / 2, (coloredPanel.Height - building.Height) / 2);
                }
            }
            coloredPanel.Controls.Add(building);
            coloredPanel.Invalidate();
        }
    }
}
