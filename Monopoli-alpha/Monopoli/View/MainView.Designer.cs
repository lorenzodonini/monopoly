namespace Monopoli
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this._welcomePanel = new System.Windows.Forms.Panel();
            this._menuBar = new System.Windows.Forms.MenuStrip();
            this._toolStripMonopoliItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripNewGameItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripEndGameItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripHelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripRulesItem = new System.Windows.Forms.ToolStripMenuItem();
            this._welcomePanel.SuspendLayout();
            this._menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _welcomePanel
            // 
            this._welcomePanel.AutoSize = true;
            this._welcomePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._welcomePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._welcomePanel.BackgroundImage = global::Monopoli.Properties.Resources.monopoli_logo;
            this._welcomePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._welcomePanel.Controls.Add(this._menuBar);
            this._welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._welcomePanel.Location = new System.Drawing.Point(0, 0);
            this._welcomePanel.Name = "_welcomePanel";
            this._welcomePanel.Size = new System.Drawing.Size(1016, 741);
            this._welcomePanel.TabIndex = 1;
            // 
            // _menuBar
            // 
            this._menuBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this._menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMonopoliItem,
            this._toolStripHelpItem});
            this._menuBar.Location = new System.Drawing.Point(0, 0);
            this._menuBar.Name = "_menuBar";
            this._menuBar.Size = new System.Drawing.Size(1016, 24);
            this._menuBar.TabIndex = 0;
            this._menuBar.Text = "Menu";
            // 
            // _toolStripMonopoliItem
            // 
            this._toolStripMonopoliItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripNewGameItem,
            this._toolStripEndGameItem,
            this._toolStripExitItem});
            this._toolStripMonopoliItem.Name = "_toolStripMonopoliItem";
            this._toolStripMonopoliItem.Size = new System.Drawing.Size(61, 20);
            this._toolStripMonopoliItem.Text = "Monopoli";
            // 
            // _toolStripNewGameItem
            // 
            this._toolStripNewGameItem.Name = "_toolStripNewGameItem";
            this._toolStripNewGameItem.Size = new System.Drawing.Size(152, 22);
            this._toolStripNewGameItem.Text = "Nuova Partita";
            this._toolStripNewGameItem.Click += new System.EventHandler(this.ToolStripNewGameItem_Click);
            // 
            // _toolStripEndGameItem
            // 
            this._toolStripEndGameItem.Enabled = false;
            this._toolStripEndGameItem.Name = "_toolStripEndGameItem";
            this._toolStripEndGameItem.Size = new System.Drawing.Size(152, 22);
            this._toolStripEndGameItem.Text = "Termina Partita";
            this._toolStripEndGameItem.Click += new System.EventHandler(this.ToolStripEndGameItem_Click);
            // 
            // _toolStripExitItem
            // 
            this._toolStripExitItem.Name = "_toolStripExitItem";
            this._toolStripExitItem.Size = new System.Drawing.Size(152, 22);
            this._toolStripExitItem.Text = "Esci dal Gioco";
            this._toolStripExitItem.Click += new System.EventHandler(this.ToolStripExitItem_Click);
            // 
            // _toolStripHelpItem
            // 
            this._toolStripHelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripRulesItem});
            this._toolStripHelpItem.Name = "_toolStripHelpItem";
            this._toolStripHelpItem.Size = new System.Drawing.Size(40, 20);
            this._toolStripHelpItem.Text = "Help";
            // 
            // _toolStripRulesItem
            // 
            this._toolStripRulesItem.Name = "_toolStripRulesItem";
            this._toolStripRulesItem.Size = new System.Drawing.Size(152, 22);
            this._toolStripRulesItem.Text = "Regole";
            this._toolStripRulesItem.Click += new System.EventHandler(this.ToolStripRulesItem_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.Add(this._welcomePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuBar;
            this.Name = "MainView";
            this.Text = "Monopoli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._welcomePanel.ResumeLayout(false);
            this._welcomePanel.PerformLayout();
            this._menuBar.ResumeLayout(false);
            this._menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _welcomePanel;
        private System.Windows.Forms.MenuStrip _menuBar;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMonopoliItem;
        private System.Windows.Forms.ToolStripMenuItem _toolStripHelpItem;
        private System.Windows.Forms.ToolStripMenuItem _toolStripNewGameItem;
        private System.Windows.Forms.ToolStripMenuItem _toolStripEndGameItem;
        private System.Windows.Forms.ToolStripMenuItem _toolStripExitItem;
        private System.Windows.Forms.ToolStripMenuItem _toolStripRulesItem;


    }
}

