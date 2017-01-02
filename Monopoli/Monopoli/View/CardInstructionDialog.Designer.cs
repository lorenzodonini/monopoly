using System.Drawing;
namespace Monopoli.View
{
    partial class CardInstructionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cardLabel = new System.Windows.Forms.Label();
            this._instructionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._cardPanel = new System.Windows.Forms.Panel();
            this._cardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cardLabel
            // 
            this._cardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cardLabel.Location = new System.Drawing.Point(12, 9);
            this._cardLabel.Name = "_cardLabel";
            this._cardLabel.Size = new System.Drawing.Size(309, 36);
            this._cardLabel.TabIndex = 0;
            this._cardLabel.Text = "label1";
            this._cardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _instructionLabel
            // 
            this._instructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._instructionLabel.Location = new System.Drawing.Point(15, 45);
            this._instructionLabel.Name = "_instructionLabel";
            this._instructionLabel.Size = new System.Drawing.Size(303, 72);
            this._instructionLabel.TabIndex = 1;
            this._instructionLabel.Text = "label2";
            this._instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(129, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _cardPanel
            // 
            this._cardPanel.Controls.Add(this._instructionLabel);
            this._cardPanel.Controls.Add(this._cardLabel);
            this._cardPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._cardPanel.Location = new System.Drawing.Point(0, 0);
            this._cardPanel.Name = "_cardPanel";
            this._cardPanel.Size = new System.Drawing.Size(330, 129);
            this._cardPanel.TabIndex = 3;
            // 
            // CardInstructionDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(330, 170);
            this.Controls.Add(this._cardPanel);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CardInstructionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CardInstructionDialog";
            this._cardPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _cardLabel;
        private System.Windows.Forms.Label _instructionLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel _cardPanel;
    }
}