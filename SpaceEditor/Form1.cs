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

namespace SpaceEditor
{
    public partial class Form1 : Form
    {
        private Sector sector;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void getxml_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            //xmlout.Text = cg.getXML();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            string xml = cg.getXML();
            //xmlout.Text = xml;
            sector.loadCGFragment(xml);
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, this.sector.getXML());
        }

        private void Export_Click(object sender, EventArgs e)
        {
            saveFileDialog2.ShowDialog();
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string filename = saveFileDialog2.FileName;
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            File.WriteAllText(filename, cg.getXML());
        }

        private void Import_Click(object sender, EventArgs e)
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            sector.CubeGrids.Remove(cg);
            SectorTree.Nodes.Clear();
            SectorTree.Nodes.Add(sector.getTreeNode());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

       
    }
}
