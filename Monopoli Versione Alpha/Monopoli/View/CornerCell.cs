using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoli.View
{
    class CornerCell : Cell
    {
        private Image _image;
        private Label _valueLabel;
        private Label _nameLabel;

        public CornerCell(Size size, Point location, int id, string name, Image image, string currency) 
            : base(size, location, id, currency)
        {
            _image = image;
            _nameLabel = new Label();
            _nameLabel.Text = name;
            this.BackgroundImage = _image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Size = size;
            this.Name = name;
            this.Location = location;
        }

        public CornerCell(Size size, Point location, int id, string name, decimal value, Image image, string currency)
            : base(size, location, id, currency)
        {
            _image = image;
            _nameLabel = new Label();
            _nameLabel.Text = name;
            _valueLabel = new Label();
            _valueLabel.Text = value + " "+currency;
            this.BackgroundImage = _image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Size = size;
            this.Name = name;
            this.Location = location;
        }

        #region Cell
        protected override void DesignDefaultCell() { }

        protected override void Design90RotatedCell() { }

        protected override void Design180RotatedCell() { }

        protected override void Design270RotatedCell() { }

        public override void resize(int width, int height)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
