namespace SplitButtonDemo
{
    partial class Tester
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripItem2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripItem3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.nb1 = new System.Windows.Forms.Button();
            this.nb2 = new System.Windows.Forms.Button();
            this.sb2 = new AhDung.WinForm.Controls.SplitButton();
            this.sb4 = new AhDung.WinForm.Controls.SplitButton();
            this.sb3 = new AhDung.WinForm.Controls.SplitButton();
            this.sb6 = new AhDung.WinForm.Controls.SplitButton();
            this.sb5 = new AhDung.WinForm.Controls.SplitButton();
            this.sb1 = new AhDung.WinForm.Controls.SplitButton();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbMessage
            // 
            this.txbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMessage.Location = new System.Drawing.Point(12, 216);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbMessage.Size = new System.Drawing.Size(389, 183);
            this.txbMessage.TabIndex = 8;
            this.txbMessage.WordWrap = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaToolStripMenuItem,
            this.contextMenuStripItem2ToolStripMenuItem,
            this.contextMenuStripItem3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(294, 70);
            // 
            // aaToolStripMenuItem
            // 
            this.aaToolStripMenuItem.Name = "aaToolStripMenuItem";
            this.aaToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.aaToolStripMenuItem.Text = "drop down context menu strip item 1";
            this.aaToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // contextMenuStripItem2ToolStripMenuItem
            // 
            this.contextMenuStripItem2ToolStripMenuItem.Name = "contextMenuStripItem2ToolStripMenuItem";
            this.contextMenuStripItem2ToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.contextMenuStripItem2ToolStripMenuItem.Text = "drop down context menu strip item 2";
            this.contextMenuStripItem2ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // contextMenuStripItem3ToolStripMenuItem
            // 
            this.contextMenuStripItem3ToolStripMenuItem.Name = "contextMenuStripItem3ToolStripMenuItem";
            this.contextMenuStripItem3ToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.contextMenuStripItem3ToolStripMenuItem.Text = "drop down context menu strip item 3";
            this.contextMenuStripItem3ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItems_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "drop down context menu item 1";
            this.menuItem1.Click += new System.EventHandler(this.menuItems_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "drop down context menu item 2";
            this.menuItem2.Click += new System.EventHandler(this.menuItems_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "drop down context menu item 3";
            this.menuItem3.Click += new System.EventHandler(this.menuItems_Click);
            // 
            // nb1
            // 
            this.nb1.Location = new System.Drawing.Point(225, 12);
            this.nb1.Name = "nb1";
            this.nb1.Size = new System.Drawing.Size(121, 23);
            this.nb1.TabIndex = 1;
            this.nb1.Text = "Normal button";
            this.nb1.UseVisualStyleBackColor = true;
            // 
            // nb2
            // 
            this.nb2.Enabled = false;
            this.nb2.Location = new System.Drawing.Point(225, 41);
            this.nb2.Name = "nb2";
            this.nb2.Size = new System.Drawing.Size(176, 23);
            this.nb2.TabIndex = 3;
            this.nb2.Text = "Disabled normal button";
            this.nb2.UseVisualStyleBackColor = true;
            // 
            // sb2
            // 
            this.sb2.Enabled = false;
            this.sb2.Location = new System.Drawing.Point(12, 41);
            this.sb2.Name = "sb2";
            this.sb2.Size = new System.Drawing.Size(107, 23);
            this.sb2.TabIndex = 2;
            this.sb2.Text = "Disabled";
            this.sb2.UseVisualStyleBackColor = true;
            // 
            // sb4
            // 
            this.sb4.Location = new System.Drawing.Point(12, 99);
            this.sb4.Name = "sb4";
            this.sb4.Size = new System.Drawing.Size(164, 41);
            this.sb4.TabIndex = 5;
            this.sb4.Text = "Split button with long Text";
            this.sb4.UseVisualStyleBackColor = true;
            // 
            // sb3
            // 
            this.sb3.Location = new System.Drawing.Point(12, 70);
            this.sb3.Name = "sb3";
            this.sb3.Size = new System.Drawing.Size(127, 23);
            this.sb3.SplitWidth = 40;
            this.sb3.TabIndex = 4;
            this.sb3.Text = "wide Split";
            this.sb3.UseVisualStyleBackColor = true;
            // 
            // sb6
            // 
            this.sb6.Location = new System.Drawing.Point(12, 175);
            this.sb6.Name = "sb6";
            this.sb6.Size = new System.Drawing.Size(213, 23);
            this.sb6.TabIndex = 7;
            this.sb6.Text = "customize Drop down action";
            this.sb6.UseVisualStyleBackColor = true;
            // 
            // sb5
            // 
            this.sb5.Location = new System.Drawing.Point(12, 146);
            this.sb5.Name = "sb5";
            this.sb5.Size = new System.Drawing.Size(164, 23);
            this.sb5.TabIndex = 6;
            this.sb5.Text = "Drop down ContextMenu";
            this.sb5.UseVisualStyleBackColor = true;
            // 
            // sb1
            // 
            this.sb1.Location = new System.Drawing.Point(12, 12);
            this.sb1.Name = "sb1";
            this.sb1.Size = new System.Drawing.Size(107, 23);
            this.sb1.TabIndex = 0;
            this.sb1.Text = "Split button";
            this.sb1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 411);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.nb2);
            this.Controls.Add(this.sb2);
            this.Controls.Add(this.nb1);
            this.Controls.Add(this.sb4);
            this.Controls.Add(this.sb3);
            this.Controls.Add(this.sb6);
            this.Controls.Add(this.sb5);
            this.Controls.Add(this.sb1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tester";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaToolStripMenuItem;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private AhDung.WinForm.Controls.SplitButton sb1;
        private System.Windows.Forms.Button nb1;
        private AhDung.WinForm.Controls.SplitButton sb2;
        private System.Windows.Forms.Button nb2;
        private AhDung.WinForm.Controls.SplitButton sb3;
        private AhDung.WinForm.Controls.SplitButton sb4;
        private AhDung.WinForm.Controls.SplitButton sb5;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStripItem2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuStripItem3ToolStripMenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private AhDung.WinForm.Controls.SplitButton sb6;
    }
}

