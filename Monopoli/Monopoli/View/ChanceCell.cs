using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    class ChanceCell : Cell
    {
        private Label _nameLabel;
        private PictureBox _picture = new PictureBox();
        private Image _image;

        public ChanceCell(int id, DefaultCellsFactory.Position position, Size size, Point location, string name, Image image, string currency)
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
            //nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);
            _picture.SizeMode = PictureBoxSizeMode.Zoom;
            this.BackColor = Color.White;
            this.Controls.Add(_nameLabel);
            this.Controls.Add(_picture);
            this.ResumeLayout();
        }

        //Bottom side of the Board
        protected override void DesignDefaultCell()
        {
            _nameLabel = new Label();
            _nameLabel.Size = new System.Drawing.Size(Size.Width, Size.Height / 5);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5) * 4);
            _picture.Location = new System.Drawing.Point(0, Size.Height / 5);
        }

        //Left side of the Board
        protected override void Design90RotatedCell()
        {
            _nameLabel = new ClockwiseRotatedLabel();
            _nameLabel.Size = new System.Drawing.Size(Size.Width / 5, Size.Height);
            _nameLabel.Location = new System.Drawing.Point((Size.Width / 5) * 4, 0);
            _image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size((Size.Width / 5) * 4, Size.Height);
            _picture.Location = new System.Drawing.Point(0, 0);
        }

        //Top side of the Board
        protected override void Design180RotatedCell()
        {
            _nameLabel = new Label();
            _nameLabel.Size = new System.Drawing.Size(Size.Width, Size.Height / 5);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size(Size.Width, (Size.Height / 5) * 4);
            _picture.Location = new System.Drawing.Point(0, (Size.Height / 5));
        }

        //Right side of the Board
        protected override void Design270RotatedCell()
        {
            _nameLabel = new CounterClockwiseRotatedLabel();
            _nameLabel.Size = new System.Drawing.Size(Size.Width / 5, Size.Height);
            _nameLabel.Location = new System.Drawing.Point(0, 0);
            _image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            _picture.Image = _image;
            _picture.Size = new System.Drawing.Size((Size.Width / 5) * 4, Size.Height);
            _picture.Location = new System.Drawing.Point(Size.Width / 5, 0);
        }

        public override void resize(int width)
        {
            throw new NotImplementedException();
        }
    }
}
