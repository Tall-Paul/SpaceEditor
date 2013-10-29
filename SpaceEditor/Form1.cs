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

namespace SpaceEditor
{
    public partial class Form1 : Form
    {
        private Sector sector;
        private string myVersion = "0.8.6";

        public Form1()
        {
            InitializeComponent();
            this.Text = "SpaceEditor v" + myVersion + " (tall-paul.co.uk)";
                try
                {
                    string updateInfo = (new WebClient()).DownloadString("http://www.tall-paul.co.uk/spaceedit.txt");
                    string[] lines = Regex.Split(updateInfo, @"\r?\n|\r");
                    Console.WriteLine(lines.Count());
                    if (lines.Count() <= 3)
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
            //xmlout.Text = xml;
            sector.loadCGFragment(xml);
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
                this.sector.loadFromXML(file);
                SectorTree.Nodes.Add(sector.getTreeNode());
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
                sector.loadCGFragment(xml);
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
            cg.mirror("X", sector.rnd);
        }

        private void yAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.mirror("Y", sector.rnd);
        }

        private void zAxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            cg.mirror("Z", sector.rnd);
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }


    

       
    }
}
