using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monopoli.View
{
    public class WarningMessageBox : Form
    {
        private static WarningMessageBox _messageBox;
        private System.Windows.Forms.Label _messageLabel;
        private System.Windows.Forms.Button _yesButton;
        private System.Windows.Forms.Button _noButton;
        private System.Windows.Forms.Button _okButton;

        private WarningMessageBox()
        {
            InitializeComponent();
        }

        public static WarningMessageBox GetMessageBoxInstance()
        {
            if (_messageBox == null)
            {
                _messageBox = new WarningMessageBox();
            }
            return _messageBox;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._messageLabel = new System.Windows.Forms.Label();
            this._yesButton = new System.Windows.Forms.Button();
            this._noButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _messageLabel
            // 
            this._messageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this._messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._messageLabel.Location = new System.Drawing.Point(0, 0);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(322, 58);
            this._messageLabel.TabIndex = 0;
            this._messageLabel.Text = "label1";
            this._messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _yesButton
            // 
            this._yesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this._yesButton.Location = new System.Drawing.Point(154, 61);
            this._yesButton.Name = "_yesButton";
            this._yesButton.Size = new System.Drawing.Size(75, 23);
            this._yesButton.TabIndex = 1;
            this._yesButton.Text = "Sì";
            this._yesButton.UseVisualStyleBackColor = true;
            // 
            // _noButton
            // 
            this._noButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this._noButton.Location = new System.Drawing.Point(235, 61);
            this._noButton.Name = "_noButton";
            this._noButton.Size = new System.Drawing.Size(75, 23);
            this._noButton.TabIndex = 2;
            this._noButton.Text = "No";
            this._noButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(73, 61);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 3;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // WarningMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(322, 90);
            this.ControlBox = false;
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._noButton);
            this.Controls.Add(this._yesButton);
            this.Controls.Add(this._messageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarningMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WarningMessageBox";
            this.ResumeLayout(false);

        }

        #endregion

        public DialogResult ShowDialogWithData(string message, string question, MessageBoxButtons buttons)
        {
            if (buttons == MessageBoxButtons.YesNo)
            {
                _okButton.Visible = false;
                _yesButton.Visible = true;
                _noButton.Visible = true;
                _yesButton.Focus();
            }
            else if (buttons == MessageBoxButtons.OK)
            {
                _okButton.Visible = true;
                _yesButton.Visible = false;
                _noButton.Visible = false;
                _okButton.Focus();
            }
            if (!String.IsNullOrEmpty(question))
            {
                this.Text = question;
            }
            else
            {
                this.Text = "Risultato Dadi";
            }
            if (!String.IsNullOrEmpty(message))
            {
                _messageLabel.Text = message;
            }
            return this.ShowDialog();
        }
    }
}
