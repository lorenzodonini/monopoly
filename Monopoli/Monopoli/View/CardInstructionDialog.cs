using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoli.View
{
    public partial class CardInstructionDialog : Form
    {
        public CardInstructionDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialogWithData(string card, string instructions, Color color)
        {
            this._cardLabel.Text = card;
            this._instructionLabel.Text = instructions;
            this._cardPanel.BackColor = color;
            return base.ShowDialog();
        }
    }
}
