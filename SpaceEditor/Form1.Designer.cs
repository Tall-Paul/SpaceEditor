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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loggingCheck = new System.Windows.Forms.CheckBox();
            this.savegamesbox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.shipcontainerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.shipcontainerMenu.SuspendLayout();
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
            // saveFileDialog2
            //             
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
            this.thumbnailToolStripMenuItem.Click += new System.EventHandler(this.thumbnailToolStripMenuItem_Click);
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
            this.SectorTree.Location = new System.Drawing.Point(12, 40);
            this.SectorTree.Name = "SectorTree";
            this.SectorTree.Size = new System.Drawing.Size(423, 370);
            this.SectorTree.TabIndex = 12;
            this.SectorTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.SectorTree_AfterLabelEdit);
            this.SectorTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SectorTree_AfterSelect);
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
            // savegamesbox
            // 
            this.savegamesbox.FormattingEnabled = true;
            this.savegamesbox.Location = new System.Drawing.Point(12, 9);
            this.savegamesbox.Name = "savegamesbox";
            this.savegamesbox.Size = new System.Drawing.Size(163, 24);
            this.savegamesbox.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 25);
            this.button1.TabIndex = 17;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(328, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 25);
            this.button2.TabIndex = 18;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(383, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 25);
            this.button3.TabIndex = 19;
            this.button3.Text = "Copy";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 20;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(181, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 25);
            this.button4.TabIndex = 21;
            this.button4.Text = "Q Load";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.cleanupToolStripMenuItem.Click += new System.EventHandler(this.cleanupToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 436);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.savegamesbox);
            this.Controls.Add(this.loggingCheck);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SectorTree);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SpaceEditor v0.8.2 (tall-paul.co.uk)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.shipmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.shipcontainerMenu.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem thumbnailToolStripMenuItem;
        private System.Windows.Forms.CheckBox loggingCheck;
        private System.Windows.Forms.ToolStripMenuItem importModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.ComboBox savegamesbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ContextMenuStrip shipcontainerMenu;
        private System.Windows.Forms.ToolStripMenuItem importShipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanupToolStripMenuItem;
    }
}

