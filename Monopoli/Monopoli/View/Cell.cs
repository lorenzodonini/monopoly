using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    public abstract class Cell : Panel
    {
        protected readonly decimal ratio = 1.6m;
        protected string _currency;

        protected Cell(int id, Size size, Point location, string currency)
        {
            this.SuspendLayout();
            this.Size = size;
            this.Location = location;
            this.Tag = id;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            _currency = currency;
        }
        protected abstract void DesignDefaultCell();

        protected abstract void Design90RotatedCell();

        protected abstract void Design180RotatedCell();

        protected abstract void Design270RotatedCell();
        
        public abstract void resize(int width);

        internal void DrawMarker(PictureBox marker)
        {
            if (marker.Parent != null)
                marker.Parent.Controls.Remove(marker);
            int playersHere = this.Controls.OfType<PictureBox>().ToArray().Length;
            if ((Int32)this.Tag <= 10)
            {
                marker.Size = new Size(this.Width / 3, this.Height / 4);
                marker.Location = new Point((this.Width / 2 * playersHere + (this.Width / 2 - marker.Width) / 2 + 1) % this.Width,
                    this.Height / 5 + (this.Width / 2 * playersHere + (this.Width / 2 - marker.Width) / 2 + 1) / this.Width * this.Height * 4 / 5 / 3);
            }
            else if ((Int32)this.Tag > 10 && (Int32)this.Tag < 20)
            {
                marker.Size = new Size(this.Width / 4, this.Height / 3);
                marker.Location = new Point((this.Width / 3 * playersHere + (this.Width / 3 - marker.Width) / 2 + 1) % this.Width,
                    (this.Width / 3 * playersHere + (this.Width / 3 - marker.Width) / 2 + 1) / this.Width * this.Height / 2);
            }
            else if ((Int32)this.Tag >= 20 && (Int32)this.Tag <= 30)
            {
                marker.Size = new Size(this.Width / 3, this.Height / 4);
                marker.Location = new Point((this.Width / 2 * playersHere + (this.Width / 2 - marker.Width) / 2 + 1) % this.Width,
                    (this.Width / 2 * playersHere + (this.Width / 2 - marker.Width) / 2 + 1) / this.Width * this.Height * 4 / 5 / 3);
            }
            else
            {
                marker.Size = new Size(this.Width / 4, this.Height / 3);
                marker.Location = new Point(this.Width / 5 + (this.Width / 3 * playersHere + (this.Width / 3 - marker.Width) / 2 + 1) % this.Width,
                    (this.Width / 3 * playersHere + (this.Width / 3 - marker.Width) / 2 + 1) / this.Width * this.Height / 2);
            }
            marker.BackColor = Color.Transparent;
            this.Controls.Add(marker);
            this.Controls.SetChildIndex(marker, 0);
            this.Invalidate();
        }
    }
}
