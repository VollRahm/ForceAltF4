namespace ForceAltF4
{
    partial class mainFrm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.autostartItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitItem,
            this.activeStripItem,
            this.autostartItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(123, 22);
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // activeStripItem
            // 
            this.activeStripItem.Checked = true;
            this.activeStripItem.CheckOnClick = true;
            this.activeStripItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeStripItem.Name = "activeStripItem";
            this.activeStripItem.Size = new System.Drawing.Size(123, 22);
            this.activeStripItem.Text = "Active";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "ForceAltF4";
            this.notifyIcon.BalloonTipTitle = "lel";
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Text = "ForceAltF4";
            this.notifyIcon.Visible = true;
            // 
            // autostartItem
            // 
            this.autostartItem.CheckOnClick = true;
            this.autostartItem.Name = "autostartItem";
            this.autostartItem.Size = new System.Drawing.Size(180, 22);
            this.autostartItem.Text = "Autostart";
            this.autostartItem.Click += new System.EventHandler(this.autostartItem_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 177);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainFrm";
            this.ShowInTaskbar = false;
            this.Text = "ForceAltF4";
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem activeStripItem;
        private System.Windows.Forms.ToolStripMenuItem autostartItem;
    }
}

