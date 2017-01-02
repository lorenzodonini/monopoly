namespace Monopoli.View
{
    partial class PropertyInfoDialog
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
            this._propertyList = new System.Windows.Forms.ListBox();
            this._infoLabel = new System.Windows.Forms.Label();
            this._propertyOwnerLabel = new System.Windows.Forms.Label();
            this._returnButton = new System.Windows.Forms.Button();
            this._propertyDataLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _propertyList
            // 
            this._propertyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._propertyList.FormattingEnabled = true;
            this._propertyList.ItemHeight = 16;
            this._propertyList.Location = new System.Drawing.Point(12, 59);
            this._propertyList.Name = "_propertyList";
            this._propertyList.ScrollAlwaysVisible = true;
            this._propertyList.Size = new System.Drawing.Size(285, 116);
            this._propertyList.TabIndex = 0;
            this._propertyList.SelectedIndexChanged += new System.EventHandler(this.SelectedProperty_Changed);
            // 
            // _infoLabel
            // 
            this._infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._infoLabel.Location = new System.Drawing.Point(12, 9);
            this._infoLabel.Name = "_infoLabel";
            this._infoLabel.Size = new System.Drawing.Size(285, 43);
            this._infoLabel.TabIndex = 1;
            this._infoLabel.Text = "Selezionare il Terreno di cui si vogliono visualizzare le informazioni:";
            this._infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _propertyOwnerLabel
            // 
            this._propertyOwnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._propertyOwnerLabel.Location = new System.Drawing.Point(12, 185);
            this._propertyOwnerLabel.Name = "_propertyOwnerLabel";
            this._propertyOwnerLabel.Size = new System.Drawing.Size(285, 25);
            this._propertyOwnerLabel.TabIndex = 2;
            this._propertyOwnerLabel.Text = "label2";
            this._propertyOwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _returnButton
            // 
            this._returnButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._returnButton.Location = new System.Drawing.Point(65, 268);
            this._returnButton.Name = "_returnButton";
            this._returnButton.Size = new System.Drawing.Size(185, 25);
            this._returnButton.TabIndex = 3;
            this._returnButton.Text = "Torna alla Partita";
            this._returnButton.UseVisualStyleBackColor = true;
            // 
            // _propertyDataLabel
            // 
            this._propertyDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._propertyDataLabel.Location = new System.Drawing.Point(12, 210);
            this._propertyDataLabel.Name = "_propertyDataLabel";
            this._propertyDataLabel.Size = new System.Drawing.Size(285, 50);
            this._propertyDataLabel.TabIndex = 4;
            this._propertyDataLabel.Text = "label2";
            this._propertyDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PropertyInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 305);
            this.Controls.Add(this._propertyDataLabel);
            this.Controls.Add(this._returnButton);
            this.Controls.Add(this._propertyOwnerLabel);
            this.Controls.Add(this._infoLabel);
            this.Controls.Add(this._propertyList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PropertyInfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizza Informazioni";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _propertyList;
        private System.Windows.Forms.Label _infoLabel;
        private System.Windows.Forms.Label _propertyOwnerLabel;
        private System.Windows.Forms.Button _returnButton;
        private System.Windows.Forms.Label _propertyDataLabel;
    }
}