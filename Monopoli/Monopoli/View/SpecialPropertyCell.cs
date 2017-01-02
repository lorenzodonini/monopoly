using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    class SpecialPropertyCell : Cell
    {
        private Label _nameLabel;
        private Label _valueLabel;
        private PictureBox _picture = new PictureBox();
        private Image _image;

        public SpecialPropertyCell(int id, DefaultCellsFactory.Position position, Size size, Point location, string name, 
            decimal value, string group, Image image, string currency)
            : base(id, size, location, currency)
        {
            _image = (Image)image.Clone();
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
            this.Name = name;
            _nameLabel.Text = name;
            _nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            _valueLabel.Text = currency +" "+ value.ToString();
            _valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            this.BackColor = Color.White;
            this.Controls.Add(_nameLabel);
            this.Controls.Add(_valueLabel);
            this.Controls.Add(_picture);
            this.ResumeLayout();
        }

        //Bottom side of the Board
        protected override void DesignDefaultCell()
        {
            _nameLabel = new Label();
            _valueLabel = new Label();
            _nameLabel.Size = new System.Drawing.Size(Size.Width, Size.Height / 5 * 2);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5) * 2);
            _picture.Location = new System.Drawing.Point(0, Size.Height / 5 * 2);
            _valueLabel.Size = new System.Drawing.Size(Size.Width, Size.Height / 5);
            _valueLabel.Location = new System.Drawing.Point(0, (Size.Height / 5) * 4);
        }

        //Left side of the Board
        protected override void Design90RotatedCell()
        {
            _nameLabel = new ClockwiseRotatedLabel();
            _valueLabel = new ClockwiseRotatedLabel();
            _nameLabel.Size = new System.Drawing.Size(Size.Width / 5 * 2, Size.Height);
            _nameLabel.Location = new System.Drawing.Point((Size.Width / 5) * 3, 0);
            _image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size((Size.Width / 5) * 2, Size.Height);
            _picture.Location = new System.Drawing.Point(Size.Width / 5, 0);
            _valueLabel.Size = new System.Drawing.Size(Size.Width / 5, Size.Height);
            _valueLabel.Location = new System.Drawing.Point(0, 0);
        }

        //Top side of the Board
        protected override void Design180RotatedCell()
        {
            _nameLabel = new Label();
            _valueLabel = new Label();
            _nameLabel.Size = new System.Drawing.Size(Size.Width, Size.Height / 7 * 3);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size(Size.Width, (Size.Height / 7) * 3);
            _picture.Location = new System.Drawing.Point(0, Size.Height / 7 * 3);
            _valueLabel.Size = new System.Drawing.Size(Size.Width, Size.Height / 7);
            _valueLabel.Location = new System.Drawing.Point(0, (Size.Height / 7) * 6);
        }

        //Right side of the Board
        protected override void Design270RotatedCell()
        {
            _nameLabel = new CounterClockwiseRotatedLabel();
            _valueLabel = new CounterClockwiseRotatedLabel();
            _nameLabel.Size = new System.Drawing.Size(Size.Width / 5 * 2, Size.Height);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size((Size.Width / 5) * 2, Size.Height);
            _picture.Location = new System.Drawing.Point(Size.Width / 5 * 2, 0);
            _valueLabel.Size = new System.Drawing.Size(Size.Width / 5, Size.Height);
            _valueLabel.Location = new System.Drawing.Point((Size.Width / 5) * 4, 0);
        }

        public override void resize(int width)
        {
            throw new NotImplementedException();
        }
    }
}
