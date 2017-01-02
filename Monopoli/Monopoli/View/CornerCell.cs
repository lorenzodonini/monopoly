using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Monopoli.View
{
    class CornerCell : Cell
    {
        public CornerCell(int id, Size size, Point location, string name, Image image, string currency) 
            : base(id, size, location, currency)
        {
            this.BackgroundImage = image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Size = size;
            this.Name = name;
            this.Location = location;
        }

        public CornerCell(int id, Size size, Point location, string name, decimal value, Image image, string currency)
            : base(id, size, location, currency)
        {
            this.BackgroundImage = image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Size = size;
            this.Name = name;
            this.Location = location;
        }

        public override void resize(int width)
        {
            this.Height = width;
            this.Width = width;
        }


        protected override void DesignDefaultCell() { }

        protected override void Design90RotatedCell() { }

        protected override void Design180RotatedCell() { }

        protected override void Design270RotatedCell() { }
    }
}
