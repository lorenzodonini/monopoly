using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Monopoli.View
{
    class CounterClockwiseRotatedLabel : Label
    {
        Graphics _graphics;
        private float _YAlignment = 0;
        private float _XAlignment = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            _graphics = e.Graphics;

            Align();

            Format();

            _graphics.RotateTransform(-90);
            _graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), _YAlignment-this.Height, _XAlignment);
            _graphics.ResetTransform();
        }

        private void Align()
        {
            if (this.TextAlign == System.Drawing.ContentAlignment.MiddleCenter)
            {
                _YAlignment = (this.Height - _graphics.MeasureString(this.Text, this.Font).Width) / 2;
                _XAlignment = (this.Width - _graphics.MeasureString(this.Text, this.Font).Height) / 2;
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.MiddleLeft)
            {
                _YAlignment = (this.Height - _graphics.MeasureString(this.Text, this.Font).Width) / 2;
                _XAlignment = 0;
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.MiddleRight)
            {
                _YAlignment = (this.Height - _graphics.MeasureString(this.Text, this.Font).Width) / 2;
                _XAlignment = (this.Width - _graphics.MeasureString(this.Text, this.Font).Height);
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.BottomCenter)
            {
                _YAlignment = 0;
                _XAlignment = (this.Width - _graphics.MeasureString(this.Text, this.Font).Height) / 2;
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.BottomLeft)
            {
                _YAlignment = 0;
                _XAlignment = 0;
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.BottomRight)
            {
                _YAlignment = 0;
                _XAlignment = (this.Width - _graphics.MeasureString(this.Text, this.Font).Height);
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.TopCenter)
            {
                _YAlignment = (this.Height - _graphics.MeasureString(this.Text, this.Font).Width);
                _XAlignment = (this.Width - _graphics.MeasureString(this.Text, this.Font).Height) / 2;
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.TopLeft)
            {
                _YAlignment = (this.Height - _graphics.MeasureString(this.Text, this.Font).Width);
                _XAlignment = 0;
            }
            else if (this.TextAlign == System.Drawing.ContentAlignment.TopRight)
            {
                _YAlignment = (this.Height - _graphics.MeasureString(this.Text, this.Font).Width);
                _XAlignment = (this.Width - _graphics.MeasureString(this.Text, this.Font).Height);
            }
        }

        private void Format()
        {
            string text = this.Text;
            text = text.Replace(Environment.NewLine, "");
            if ((Int32)_graphics.MeasureString(this.Text, this.Font).Width > this.Height)
            {
                int charForLine = 1 + (Int32)(_graphics.MeasureString(this.Text, this.Font).Width / _graphics.MeasureString("a", this.Font).Width);
                string[] words = text.Split(' ');
                this.Text = words[0];
                for (int i = 1; i < words.Length; i++)
                {
                    if (this.Text.Length + words[i].Length + 1 > charForLine)
                    {
                        this.Text += Environment.NewLine + words[i];
                    }
                    else
                        this.Text += " " + words[i];
                }
            }
        }
    }
}
