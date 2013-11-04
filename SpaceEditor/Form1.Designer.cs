namespace SpaceEditor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.fileopen = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.shipmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportShipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneShipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteShipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbnailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SectorTree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.worldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loggingCheck = new System.Windows.Forms.CheckBox();
            this.shipmenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // shipmenu
            // 
            this.shipmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportShipMenuItem,
            this.cloneShipMenuItem,
            this.deleteShipMenuItem,
            this.mirrorBlocksToolStripMenuItem,
            this.thumbnailToolStripMenuItem,
            this.importModuleToolStripMenuItem,
            this.rotateToolStripMenuItem});
            this.shipmenu.Name = "treemenu";
            this.shipmenu.Size = new System.Drawing.Size(179, 200);
            // 
            // exportShipMenuItem
            // 
            this.exportShipMenuItem.Name = "exportShipMenuItem";
            this.exportShipMenuItem.Size = new System.Drawing.Size(178, 24);
            this.exportShipMenuItem.Text = "Export";
            this.exportShipMenuItem.Click += new System.EventHandler(this.exportShipMenuItem_Click);
            // 
            // cloneShipMenuItem
            // 
            this.cloneShipMenuItem.Name = "cloneShipMenuItem";
            this.cloneShipMenuItem.Size = new System.Drawing.Size(178, 24);
            this.cloneShipMenuItem.Text = "Clone";
            this.cloneShipMenuItem.Click += new System.EventHandler(this.cloneShipMenuItem_Click);
            // 
            // deleteShipMenuItem
            // 
            this.deleteShipMenuItem.Name = "deleteShipMenuItem";
            this.deleteShipMenuItem.Size = new System.Drawing.Size(178, 24);
            this.deleteShipMenuItem.Text = "Delete";
            this.deleteShipMenuItem.Click += new System.EventHandler(this.deleteShipMenuItem_Click);
            // 
            // mirrorBlocksToolStripMenuItem
            // 
            this.mirrorBlocksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xAxisToolStripMenuItem,
            this.yAxisToolStripMenuItem,
            this.zAxisToolStripMenuItem});
            this.mirrorBlocksToolStripMenuItem.Name = "mirrorBlocksToolStripMenuItem";
            this.mirrorBlocksToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.mirrorBlocksToolStripMenuItem.Text = "Mirror Blocks";
            // 
            // xAxisToolStripMenuItem
            // 
            this.xAxisToolStripMenuItem.Name = "xAxisToolStripMenuItem";
            this.xAxisToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.xAxisToolStripMenuItem.Text = "X Axis";
            this.xAxisToolStripMenuItem.Click += new System.EventHandler(this.xAxisToolStripMenuItem_Click);
            // 
            // yAxisToolStripMenuItem
            // 
            this.yAxisToolStripMenuItem.Name = "yAxisToolStripMenuItem";
            this.yAxisToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.yAxisToolStripMenuItem.Text = "Y Axis";
            this.yAxisToolStripMenuItem.Click += new System.EventHandler(this.yAxisToolStripMenuItem_Click);
            // 
            // zAxisToolStripMenuItem
            // 
            this.zAxisToolStripMenuItem.Name = "zAxisToolStripMenuItem";
            this.zAxisToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.zAxisToolStripMenuItem.Text = "Z Axis";
            this.zAxisToolStripMenuItem.Click += new System.EventHandler(this.zAxisToolStripMenuItem_Click);
            // 
            // thumbnailToolStripMenuItem
            // 
            this.thumbnailToolStripMenuItem.Name = "thumbnailToolStripMenuItem";
            this.thumbnailToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.thumbnailToolStripMenuItem.Text = "Thumbnail";
            this.thumbnailToolStripMenuItem.Visible = false;
            this.thumbnailToolStripMenuItem.Click += new System.EventHandler(this.thumbnailToolStripMenuItem_Click);
            // 
            // importModuleToolStripMenuItem
            // 
            this.importModuleToolStripMenuItem.Name = "importModuleToolStripMenuItem";
            this.importModuleToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.importModuleToolStripMenuItem.Text = "Import Module";
            this.importModuleToolStripMenuItem.Visible = false;
            this.importModuleToolStripMenuItem.Click += new System.EventHandler(this.importModuleToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.zToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Visible = false;
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.zToolStripMenuItem.Text = "Z";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // SectorTree
            // 
            this.SectorTree.LabelEdit = true;
            this.SectorTree.Location = new System.Drawing.Point(6, 34);
            this.SectorTree.Name = "SectorTree";
            this.SectorTree.Size = new System.Drawing.Size(629, 395);
            this.SectorTree.TabIndex = 12;
            this.SectorTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.SectorTree_AfterLabelEdit);
            this.SectorTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SectorTree_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.worldToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // worldToolStripMenuItem
            // 
            this.worldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importShipToolStripMenuItem});
            this.worldToolStripMenuItem.Name = "worldToolStripMenuItem";
            this.worldToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.worldToolStripMenuItem.Text = "World";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importShipToolStripMenuItem
            // 
            this.importShipToolStripMenuItem.Name = "importShipToolStripMenuItem";
            this.importShipToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.importShipToolStripMenuItem.Text = "Import Ship";
            this.importShipToolStripMenuItem.Click += new System.EventHandler(this.importShipToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(642, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(572, 395);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // loggingCheck
            // 
            this.loggingCheck.AutoSize = true;
            this.loggingCheck.Location = new System.Drawing.Point(554, 7);
            this.loggingCheck.Name = "loggingCheck";
            this.loggingCheck.Size = new System.Drawing.Size(81, 21);
            this.loggingCheck.TabIndex = 15;
            this.loggingCheck.Text = "Logging";
            this.loggingCheck.UseVisualStyleBackColor = true;
            this.loggingCheck.CheckedChanged += new System.EventHandler(this.loggingCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 436);
            this.Controls.Add(this.loggingCheck);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.SectorTree);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SpaceEditor v0.8.2 (tall-paul.co.uk)";
            this.shipmenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileopen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ContextMenuStrip shipmenu;
        private System.Windows.Forms.TreeView SectorTree;
        private System.Windows.Forms.ToolStripMenuItem exportShipMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneShipMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteShipMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem worldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importShipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mirrorBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zAxisToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem thumbnailToolStripMenuItem;
        private System.Windows.Forms.CheckBox loggingCheck;
        private System.Windows.Forms.ToolStripMenuItem importModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
    }
}

