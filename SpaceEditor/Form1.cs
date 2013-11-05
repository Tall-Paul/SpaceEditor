using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Media.Media3D;

namespace SpaceEditor
{
    public partial class Form1 : Form
    {
        private Sector sector;
        private string myVersion = "0.9.3";
        private bool loggingEnabled = false;
        public string Log = "";

        public Form1()
        {
            InitializeComponent();
            this.Text = "SpaceEditor v" + myVersion + " (tall-paul.co.uk)";
                try
                {
                    string updateInfo = (new WebClient()).DownloadString("http://www.tall-paul.co.uk/spaceedit.txt");
                    Console.WriteLine(updateInfo);
                    string[] lines = Regex.Split(updateInfo, @"\r?\n|\r");
                    Console.WriteLine(lines.Count());
                    if (lines.Count() <= 10)
                    {
                        if (lines[0] != myVersion)
                        {
                            DialogResult dialogResult = MessageBox.Show("Version "+lines[0]+" is available. Visit the site to download it?", "New Version", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Process.Start(lines[1]);
                            }
                        }
                        
                    } 
                    
                }
                catch (Exception) { }            
            
        }


        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, this.sector.getXML());
        }


        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string filename = saveFileDialog2.FileName;
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            File.WriteAllText(filename, cg.getXML());
        }




        private void SectorTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            SectorTree.LabelEdit = false;
            if (node.Tag != null)
            {
                try
                {
                    EntityBase entity = (EntityBase)node.Tag;
                    switch (entity.actualType)
                    {
                        case "Ship":
                            SectorTree.SelectedNode.ContextMenuStrip = this.shipmenu;
                            break;
                        default:
                            SectorTree.SelectedNode.ContextMenuStrip = null;
                            break;
                    }
                }
                catch (InvalidCastException)
                {
                    SectorTree.SelectedNode.ContextMenuStrip = null;
                    try
                    {
                        //is it a coord?
                        float value = float.Parse(SectorTree.SelectedNode.Text);
                        SectorTree.LabelEdit = true;
                        SectorTree.SelectedNode.BeginEdit();
                    }
                    catch (FormatException) { }
                }
            }
            else
            {              
                SectorTree.SelectedNode.ContextMenuStrip = null;
               
            }
        }

        private void exportShipMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog2.ShowDialog();
        }

        private void cloneShipMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            string xml = cg.getXML();
            CubeGrid newGrid = sector.loadCGFragment(xml,true);
            sector.CubeGrids.Add(newGrid);
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }

        private void deleteShipMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            sector.CubeGrids.Remove(cg);
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fileopen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = fileopen.FileName;
                this.sector = new Sector();
                SectorTree.Nodes.Clear();
                Log = this.sector.loadFromXML(file,loggingEnabled);
                if (loggingEnabled)
                    File.WriteAllText("./Log.txt", Log);
                Log = "";
                SectorTree.Nodes.Add(sector.getTreeNode());
                mirrorBlocksToolStripMenuItem.Visible = true;
            }
            else
            {
                //logger.Items.Add("Unable to load file");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void importShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fileopen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = fileopen.FileName;
                string xml = File.ReadAllText(filename);
                CubeGrid new_cg = sector.loadCGFragment(xml,false);
                sector.CubeGrids.Add(new_cg);
                SectorTree.Nodes.Clear();
                SectorTree.Nodes.Add(sector.getTreeNode());
            }
        }

        private void SectorTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode valueNode = SectorTree.SelectedNode;
            TreeNode coordNode = valueNode.Parent;
            coord coord = (coord)coordNode.Tag;          
            if (e.CancelEdit == true)
                return;
            string newValue = "0";
            if (string.IsNullOrWhiteSpace(e.Label))
                newValue = e.Node.Text;
            else
                newValue = e.Label;
            try
            {
                coord.setValue((string)valueNode.Tag, newValue);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("hrm, that should have been a string");
            }
        }

        private void xAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.mirror("X");
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }

        private void yAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.mirror("Y");
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }

        private void zAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.mirror("Z");
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }

        private void thumbnailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            pictureBox1.Image = cg.getThumbnail();
        }

        private void loggingCheck_CheckedChanged(object sender, EventArgs e)
        {
            loggingEnabled = loggingCheck.Checked;
        }

        

        

        private void importModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            DialogResult result = fileopen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = fileopen.FileName;
                string xml = File.ReadAllText(filename);
                CubeGrid module = sector.loadCGFragment(xml, false);
                CubeBlock module_attachment_point = module.getBlock("LargeBlockArmorSlopeWhite");
                if (module_attachment_point != null)
                {
                    //Console.WriteLine("Got module attachment");
                    TreeNode main_node = SectorTree.SelectedNode;
                    CubeGrid main = (CubeGrid)main_node.Tag;
                    CubeBlock main_attachment_point = main.getBlock("LargeBlockArmorSlopeWhite");                    
                    if (main_attachment_point != null)
                    {
                        
                        //Console.WriteLine("Got module attachment");
                        Vector3D diff = Sector.diff_orientation(main_attachment_point, module_attachment_point);
                        //Console.WriteLine("Up :" + main_attachment_point.PositionAndOrientation.up.ToString() + " " + module_attachment_point.PositionAndOrientation.up.ToString());
                        //Console.WriteLine("Forward :" + main_attachment_point.PositionAndOrientation.forward.ToString() + " " + module_attachment_point.PositionAndOrientation.forward.ToString());                        
                        module.reOrient(module_attachment_point);
                        //Console.WriteLine("module attachment point after reorient: "+module_attachment_point.PositionAndOrientation.position.ToString());
                        main.reOrient(main_attachment_point);                        
                        //lets try some rotation
                        module.rotate_grid("X", coord.RadianToSteps(diff.X));
                        module.rotate_grid("Y", coord.RadianToSteps(diff.Y));
                        module.rotate_grid("Z", coord.RadianToSteps(diff.Z));
                        Console.WriteLine("Difference " + coord.RadianToDegrees(diff.X) + " " + coord.RadianToDegrees(diff.Y) + " " + coord.RadianToDegrees(diff.Z));
                        diff = Sector.diff_orientation(module_attachment_point, main_attachment_point);
                        Console.WriteLine("After Rotation Difference: "+ coord.RadianToDegrees(diff.X) + " " + coord.RadianToDegrees(diff.Y) + " " + coord.RadianToDegrees(diff.Z));
                        Console.WriteLine("Up :" + main_attachment_point.PositionAndOrientation.up.ToString() + " " + module_attachment_point.PositionAndOrientation.up.ToString());
                        Console.WriteLine("Forward :" + main_attachment_point.PositionAndOrientation.forward.ToString() + " " + module_attachment_point.PositionAndOrientation.forward.ToString());
                        return;
                        main.merge(module);
                        SectorTree.Nodes.Clear();
                        SectorTree.Nodes.Add(sector.getTreeNode());
                    }

                }
                else
                {
                    Console.WriteLine("Couldn't get module attachment");
                }
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.rotate_grid("X", 1);
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.rotate_grid("Y", 1);
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.rotate_grid("Z", 1);
        }

        private void fileopen_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void QuickLoadMenuItem1_Click(object sender, EventArgs e)
        {
            bool quick = false;
            DialogResult dialogResult = MessageBox.Show("Quick load is currently considered unstable, proceed with caution and always make a backup! \r\n\r\n  Hit 'Yes' to continue or 'No' to do a standard load.", "Quick load?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                quick = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                quick = false;
            }
            DialogResult result = fileopen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = fileopen.FileName;
                this.sector = new Sector();
                SectorTree.Nodes.Clear();
                Log = this.sector.loadFromXML(file, loggingEnabled,quick);
                if (loggingEnabled)
                    File.WriteAllText("./Log.txt", Log);
                Log = "";
                SectorTree.Nodes.Add(sector.getTreeNode());
                mirrorBlocksToolStripMenuItem.Visible = false;
            }
            else
            {
                //logger.Items.Add("Unable to load file");
            }
        }




    

       
    }
}
