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
            this.label1 = new System.Windows.Forms.Label();
            this.shipcontainerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewEntityMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleStaticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importShipToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.regenerateIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipmenu.SuspendLayout();
            this.shipcontainerMenu.SuspendLayout();
            this.NewEntityMenuStrip1.SuspendLayout();
            this.saveGameMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileopen
            // 
            this.fileopen.FileOk += new System.ComponentModel.CancelEventHandler(this.fileopen_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
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
            this.shipmenu.Size = new System.Drawing.Size(179, 172);
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
            // 
            // importModuleToolStripMenuItem
            // 
            this.importModuleToolStripMenuItem.Name = "importModuleToolStripMenuItem";
            this.importModuleToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.importModuleToolStripMenuItem.Text = "Import Module";
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
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.zToolStripMenuItem.Text = "Z";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // SectorTree
            // 
            this.SectorTree.LabelEdit = true;
            this.SectorTree.Location = new System.Drawing.Point(12, 12);
            this.SectorTree.Name = "SectorTree";
            this.SectorTree.Size = new System.Drawing.Size(423, 412);
            this.SectorTree.TabIndex = 12;
            this.SectorTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.SectorTree_AfterLabelEdit);
            this.SectorTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SectorTree_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 20;
            // 
            // shipcontainerMenu
            // 
            this.shipcontainerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importShipToolStripMenuItem,
            this.cleanupToolStripMenuItem});
            this.shipcontainerMenu.Name = "shipcontainerMenu";
            this.shipcontainerMenu.Size = new System.Drawing.Size(157, 52);
            // 
            // importShipToolStripMenuItem
            // 
            this.importShipToolStripMenuItem.Name = "importShipToolStripMenuItem";
            this.importShipToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.importShipToolStripMenuItem.Text = "Import Ship";
            this.importShipToolStripMenuItem.Click += new System.EventHandler(this.importShipToolStripMenuItem_Click_1);
            // 
            // cleanupToolStripMenuItem
            // 
            this.cleanupToolStripMenuItem.Name = "cleanupToolStripMenuItem";
            this.cleanupToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.cleanupToolStripMenuItem.Text = "Cleanup";
            // 
            // NewEntityMenuStrip1
            // 
            this.NewEntityMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.toggleStaticToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.regenerateIDsToolStripMenuItem});
            this.NewEntityMenuStrip1.Name = "NewEntityMenuStrip1";
            this.NewEntityMenuStrip1.Size = new System.Drawing.Size(180, 148);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.cloneToolStripMenuItem.Text = "Clone";
            this.cloneToolStripMenuItem.Visible = false;
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // toggleStaticToolStripMenuItem
            // 
            this.toggleStaticToolStripMenuItem.Name = "toggleStaticToolStripMenuItem";
            this.toggleStaticToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.toggleStaticToolStripMenuItem.Text = "Toggle Static";
            this.toggleStaticToolStripMenuItem.Click += new System.EventHandler(this.toggleStaticToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // saveGameMenuStrip1
            // 
            this.saveGameMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.makeCopyToolStripMenuItem,
            this.importShipToolStripMenuItem1,
            this.cleanupToolStripMenuItem1});
            this.saveGameMenuStrip1.Name = "saveGameMenuStrip1";
            this.saveGameMenuStrip1.Size = new System.Drawing.Size(157, 124);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click_1);
            // 
            // makeCopyToolStripMenuItem
            // 
            this.makeCopyToolStripMenuItem.Name = "makeCopyToolStripMenuItem";
            this.makeCopyToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.makeCopyToolStripMenuItem.Text = "Make Copy";
            this.makeCopyToolStripMenuItem.Click += new System.EventHandler(this.makeCopyToolStripMenuItem_Click);
            // 
            // importShipToolStripMenuItem1
            // 
            this.importShipToolStripMenuItem1.Name = "importShipToolStripMenuItem1";
            this.importShipToolStripMenuItem1.Size = new System.Drawing.Size(156, 24);
            this.importShipToolStripMenuItem1.Text = "Import Ship";
            this.importShipToolStripMenuItem1.Click += new System.EventHandler(this.importShipToolStripMenuItem1_Click);
            // 
            // cleanupToolStripMenuItem1
            // 
            this.cleanupToolStripMenuItem1.Name = "cleanupToolStripMenuItem1";
            this.cleanupToolStripMenuItem1.Size = new System.Drawing.Size(156, 24);
            this.cleanupToolStripMenuItem1.Text = "Cleanup";
            this.cleanupToolStripMenuItem1.Visible = false;
            this.cleanupToolStripMenuItem1.Click += new System.EventHandler(this.cleanupToolStripMenuItem1_Click);
            // 
            // regenerateIDsToolStripMenuItem
            // 
            this.regenerateIDsToolStripMenuItem.Name = "regenerateIDsToolStripMenuItem";
            this.regenerateIDsToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.regenerateIDsToolStripMenuItem.Text = "Regenerate IDs";
            this.regenerateIDsToolStripMenuItem.Click += new System.EventHandler(this.regenerateIDsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SectorTree);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(464, 481);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(464, 481);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SpaceEditor v0.8.2 (tall-paul.co.uk)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.shipmenu.ResumeLayout(false);
            this.shipcontainerMenu.ResumeLayout(false);
            this.NewEntityMenuStrip1.ResumeLayout(false);
            this.saveGameMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem mirrorBlocksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zAxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thumbnailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip shipcontainerMenu;
        private System.Windows.Forms.ToolStripMenuItem importShipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip NewEntityMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleStaticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip saveGameMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importShipToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cleanupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regenerateIDsToolStripMenuItem;
    }
}

