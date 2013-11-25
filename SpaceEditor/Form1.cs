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
using Microsoft.Win32;
using System.Security.Permissions;
using Sandbox.CommonLib.ObjectBuilders;
using Sandbox.CommonLib.ObjectBuilders.Voxels;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum,
    ViewAndModify = "HKEY_CURRENT_USER")]

namespace SpaceEditor
{
    public partial class Form1 : Form
    {
        private Sector sector;
        private MyObjectBuilder_Sector mySector = null;

        private string myVersion = "2.0.1";
        private bool loggingEnabled = false;
        public string Log = "";
        public string steam_install_path = "";
        public string saves_path = "";
        public static Random rnd = new Random();

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




        public void update_status(string text)
        {
            this.label1.Text = text;
            this.label1.Refresh();
            Application.DoEvents();
        }

        private void SectorTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

                this.sectortree_select();
                return;

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
                    catch (FormatException) {
                        
                    }
                }
            }
            else
            {
                try
                {
                    Console.WriteLine(SectorTree.SelectedNode.Text);
                    if (SectorTree.SelectedNode.Text == "Ships / stations")
                    {
                        SectorTree.SelectedNode.ContextMenuStrip = this.shipcontainerMenu;
                    }
                    else
                    {
                        this.sectortree_select();
                    }
                }
                catch { }
               
            }
        }

        private void exportShipMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = saveFileDialog2.FileName;
                TreeNode node = SectorTree.SelectedNode;
                CubeGrid cg = (CubeGrid)node.Tag;
                File.WriteAllText(filename, cg.getXML());
                this.update_status("");
            }
            
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
                this.sector = new Sector(this);
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

        /*
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
        */
        

        

        private void importModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            TreeNode node = SectorTree.SelectedNode;
            CubeGrid cg = (CubeGrid)node.Tag;
            DialogResult result = fileopen.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.update_status("Importing Module");
                string filename = fileopen.FileName;
                string xml = File.ReadAllText(filename);
                CubeGrid module = sector.loadCGFragment(xml, false);
                CubeBlock module_attachment_point = module.getBlock("LargeBlockArmorCornerInvWhite");
                if (module_attachment_point != null)
                {
                    //Console.WriteLine("Got module attachment");
                    TreeNode main_node = SectorTree.SelectedNode;
                    CubeGrid main = (CubeGrid)main_node.Tag;
                    CubeBlock main_attachment_point = main.getBlock("LargeBlockArmorCornerInvWhite");                    
                    if (main_attachment_point != null)
                    {

                        Console.WriteLine("Before rotation!!");
                        VRageMath.Vector3 diff = Sector.diff_orientation(main_attachment_point, module_attachment_point);
                        
                        //Console.WriteLine("Got module attachment");
                        
                        //Console.WriteLine("Up :" + main_attachment_point.PositionAndOrientation.up.ToString() + " " + module_attachment_point.PositionAndOrientation.up.ToString());
                        //Console.WriteLine("Forward :" + main_attachment_point.PositionAndOrientation.forward.ToString() + " " + module_attachment_point.PositionAndOrientation.forward.ToString());                        
                        module.reOrient(module_attachment_point);
                        //Console.WriteLine("module attachment point after reorient: "+module_attachment_point.PositionAndOrientation.position.ToString());
                        main.reOrient(main_attachment_point);                                                
                        //lets try some rotation
                        Console.WriteLine("Steps: " + vrageMath.AngleToSteps(diff.X) + " " + vrageMath.AngleToSteps(diff.Y) + " " + vrageMath.AngleToSteps(diff.Z));                        
                        module.rotate_grid("X", vrageMath.AngleToSteps(diff.X));
                        module.rotate_grid("Y", vrageMath.AngleToSteps(diff.Y));
                        module.rotate_grid("Z", vrageMath.AngleToSteps(diff.Z));
                        Console.WriteLine("After rotation!!");
                       diff = Sector.diff_orientation(module_attachment_point, main_attachment_point);
                       

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
            this.update_status("");
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
                this.sector = new Sector(this);
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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<int> rot_x = new List<int>();
            List<int> rot_y = new List<int>();
            List<int> rot_z = new List<int>();
            rot_x.Add(0);
            rot_x.Add(90);
            rot_x.Add(180);
            rot_x.Add(-90);
            rot_y.AddRange(rot_x);
            rot_z.AddRange(rot_x);

            Quaternion test_rotation = MathStuff.quat_from_angles(90, 0, 0);
            Console.WriteLine("here");
            foreach (int x in rot_x)
            {
                foreach (int y in rot_y)
                {
                    foreach (int z in rot_z)
                    {
                        test_rotation = MathStuff.quat_from_angles(x, y, z);
                        Console.WriteLine("case \"" + Math.Round(test_rotation.X, 1) + " " + Math.Round(test_rotation.Y, 1) + " " + Math.Round(test_rotation.Z, 1) + " " + Math.Round(test_rotation.W, 1) + "\":");
                        Console.WriteLine("return new Vector3D("+x+","+y+","+z+");");
                    }
                }
            }


        }

        
        private void load_saves() {
            //load saves
            
            var paths = Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SpaceEngineers", "Saves"));
            if (paths != null && paths.Length > 0)
            {
                this.saves_path = paths[0];
                var saves = Directory.GetDirectories(saves_path);
                foreach (String savegame in saves)
                {
                    SectorTree.Nodes.Add(savegame.Split(Path.DirectorySeparatorChar).Last());
                   
                }
               
            }
            else
            {
                MessageBox.Show("Can't find save games!!");
            }
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //find steam installation directory
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");
            if (key != null){
                String installdir = key.GetValue("SteamPath").ToString();
                installdir += @"\steamapps\common\SpaceEngineers";
                this.steam_install_path = installdir;
                String current_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                if (!File.Exists(Path.Combine(current_path, "VRage.Math.dll")))
                {
                    if (File.Exists(Path.Combine(this.steam_install_path, "VRage.Math.dll")))
                        File.Copy(Path.Combine(this.steam_install_path, "VRage.Math.dll"), Path.Combine(current_path, "VRage.Math.dll"));
                    else
                        MessageBox.Show("Unable to locate VRage Math Library!!");
                }
                if (!File.Exists(Path.Combine(current_path, "VRage.Common.dll")))
                {
                    if (File.Exists(Path.Combine(this.steam_install_path, "VRage.Common.dll")))
                        File.Copy(Path.Combine(this.steam_install_path, "VRage.Common.dll"), Path.Combine(current_path, "VRage.Common.dll"));
                    else
                        MessageBox.Show("Unable to locate VRage Math Library!!");
                }
                if (!File.Exists(Path.Combine(current_path, "VRage.Library.dll")))
                {
                    if (File.Exists(Path.Combine(this.steam_install_path, "VRage.Library.dll")))
                        File.Copy(Path.Combine(this.steam_install_path, "VRage.Library.dll"), Path.Combine(current_path, "VRage.Library.dll"));
                    else
                        MessageBox.Show("Unable to locate VRage Math Library!!");
                }
                if (!File.Exists(Path.Combine(current_path, "SandBox.CommonLib.dll")))
                {
                    if (File.Exists(Path.Combine(this.steam_install_path, "SandBox.CommonLib.dll")))
                        File.Copy(Path.Combine(this.steam_install_path, "SandBox.CommonLib.dll"), Path.Combine(current_path, "SandBox.CommonLib.dll"));
                    else
                        MessageBox.Show("Unable to locate SandBox Common Library!!");
                }
                if (!File.Exists(Path.Combine(current_path, "SandBox.CommonLib.XmlSerializers.dll")))
                {
                    if (File.Exists(Path.Combine(this.steam_install_path, "SandBox.CommonLib.XmlSerializers.dll")))
                        File.Copy(Path.Combine(this.steam_install_path, "SandBox.CommonLib.XmlSerializers.dll"), Path.Combine(current_path, "SandBox.CommonLib.XmlSerializers.dll"));
                    else
                        MessageBox.Show("Unable to locate SandBox Common Library!!");
                }

            }
            else
            {
                MessageBox.Show("Unable to locate Steam!!");
            }
            this.load_saves();


        }


      

 

      
      

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 40, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void importShipToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = fileopen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = fileopen.FileName;
                string xml = File.ReadAllText(filename);
                CubeGrid new_cg = sector.loadCGFragment(xml, false);
                sector.CubeGrids.Add(new_cg);
                SectorTree.Nodes.Clear();
                SectorTree.Nodes.Add(sector.getTreeNode());
                this.update_status("");
            }
        }


        private void cleanupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String threshold = "";
            DialogResult result = Form1.InputBox("Cleanup","Delete any entities with less than this number of blocks",ref threshold);
            if (result == DialogResult.OK && threshold != "")
            {
                List<MyObjectBuilder_CubeGrid> deletions = new List<MyObjectBuilder_CubeGrid>();
                int thresher = int.Parse(threshold);                

                
               
            }
        }

        //###################################################################### new stuff below this line ######################//
       

        private MyObjectBuilder_CubeGrid clone_grid(MyObjectBuilder_CubeGrid old_grid)
        {
            using (MemoryStream input_stream = new MemoryStream())
            {
                MyObjectBuilder_Base.Serialize(input_stream, old_grid);                
                MyObjectBuilder_CubeGrid new_grid = (MyObjectBuilder_CubeGrid)MyObjectBuilder_Base.CreateNewObject(MyObjectBuilderTypeEnum.CubeGrid);
                using (MemoryStream output_stream = new MemoryStream()){
                    input_stream.CopyTo(output_stream);
                    output_stream.Seek(0, 0);
                    MyObjectBuilder_Base.Deserialize(output_stream, out new_grid);
                }
                
                return new_grid;
            }

        }
      
        private TreeNode newCubeGridNode(MyObjectBuilder_CubeGrid myGrid)
        {
            TreeNode node = null;
            if (myGrid.GridSizeEnum == MyCubeSize.Small)
                node = new TreeNode("Small Ship [" + myGrid.CubeBlocks.Count()+"]");
            if (myGrid.GridSizeEnum == MyCubeSize.Large)
                if (myGrid.IsStatic)
                    node = new TreeNode("Station [" + myGrid.CubeBlocks.Count() + "]");
                else
                    node = new TreeNode("Large Ship [" + myGrid.CubeBlocks.Count() + "]");
            node.Tag = myGrid;
            node.Nodes.Add(new TreeNode(myGrid.EntityId.ToString()));
            node.Nodes.Add(new TreeNode(myGrid.PositionAndOrientation.ToString()));
            node.Nodes.Add(myGrid.CubeBlocks.Count()+" Blocks");
            return node;
        }

            private void create_tree(TreeNode savegame, MyObjectBuilder_Sector mySector){
                savegame.Nodes.Clear();
                TreeNode ships = new TreeNode("Ships / Stations");
                TreeNode VoxelMaps = new TreeNode("Asteroids / Moons");
                TreeNode node = null;
                foreach (Sandbox.CommonLib.ObjectBuilders.MyObjectBuilder_EntityBase eb in mySector.SectorObjects)
                {
                    switch(eb.GetObjectBuilderTypeId()){
                        case MyObjectBuilderTypeEnum.VoxelMap:
                            MyObjectBuilder_VoxelMap myMap = (MyObjectBuilder_VoxelMap)eb;
                            node = new TreeNode("Asteroid");
                            node.Tag = myMap;
                            node.Nodes.Add(new TreeNode(myMap.EntityId.ToString()));
                            node.Nodes.Add(new TreeNode(myMap.PositionAndOrientation.ToString()));
                            node.Nodes.Add(new TreeNode(myMap.Filename.ToString()));
                            VoxelMaps.Nodes.Add(node);
                        break;
                        case MyObjectBuilderTypeEnum.CubeGrid:
                            ships.Nodes.Add(this.newCubeGridNode((MyObjectBuilder_CubeGrid)eb));
                        break;
                    }
                }
                savegame.Nodes.Add(ships);
                savegame.Nodes.Add(VoxelMaps);
                savegame.Tag = mySector;
            }

            private void sectortree_select()
            {
                SectorTree.ContextMenuStrip = null;
                if (SectorTree.SelectedNode.Text.StartsWith("Large Ship") || SectorTree.SelectedNode.Text.StartsWith("Station"))
                {
                    toggleStaticToolStripMenuItem.Visible = true;
                    SectorTree.ContextMenuStrip = NewEntityMenuStrip1;
                    return;
                }
                if (SectorTree.SelectedNode.Text.StartsWith("Small Ship"))
                {
                    toggleStaticToolStripMenuItem.Visible = false;
                    SectorTree.ContextMenuStrip = NewEntityMenuStrip1;
                    return;
                }
                if ((SectorTree.SelectedNode.Text == "Asteroids / Moons") || (SectorTree.SelectedNode.Text ==  "Ships / Stations"))
                    return;
                //default is a savegame node
                SectorTree.ContextMenuStrip = saveGameMenuStrip1;
            }

            //export ship
            private void exportToolStripMenuItem_Click(object sender, EventArgs e)
            {
                DialogResult result = saveFileDialog2.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filename = saveFileDialog2.FileName;
                    TreeNode node = SectorTree.SelectedNode;
                    MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                    switch (myBase.GetObjectBuilderTypeId())
                    {
                        case MyObjectBuilderTypeEnum.CubeGrid:                            
                            using (FileStream sr = File.Open(filename, FileMode.Create))
                            {
                                MyObjectBuilder_Base.SerializeXML(sr, (MyObjectBuilder_CubeGrid)SectorTree.SelectedNode.Tag);
                            }
                        break;
                        case MyObjectBuilderTypeEnum.VoxelMap:
                            using (FileStream sr = File.Open(filename, FileMode.Open))
                            {
                                MyObjectBuilder_Base.SerializeXML(sr, (MyObjectBuilder_VoxelMap)SectorTree.SelectedNode.Tag);
                            }
                        break;
                    }                   
                }
            }

            private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
            {
                TreeNode node = SectorTree.SelectedNode;
                MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                if (myBase.GetObjectBuilderTypeId() == MyObjectBuilderTypeEnum.CubeGrid)
                {                    

                   MyObjectBuilder_CubeGrid myGrid = this.clone_grid((MyObjectBuilder_CubeGrid)myBase);                    
                    MyPositionAndOrientation myGridPos = (MyPositionAndOrientation)myGrid.PositionAndOrientation;
                    myGridPos.Position.X = myGridPos.Position.X + 100;
                    node.Parent.Nodes.Add(newCubeGridNode(myGrid));
                }
            }

            private void toggleStaticToolStripMenuItem_Click(object sender, EventArgs e)
            {
                TreeNode node = SectorTree.SelectedNode;
                MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                if (myBase.GetObjectBuilderTypeId() == MyObjectBuilderTypeEnum.CubeGrid)
                {
                    MyObjectBuilder_CubeGrid myGrid = (MyObjectBuilder_CubeGrid)myBase;
                    if (myGrid.GridSizeEnum == MyCubeSize.Large)
                    {
                        if (myGrid.IsStatic)
                            myGrid.IsStatic = false;
                        else
                            myGrid.IsStatic = true;
                    }
                    node.Parent.Nodes.Add(this.newCubeGridNode(myGrid));
                    node.Remove();
                }
                


            }
            
        
            
            //load sector
            private void loadToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                string file = Path.Combine(this.saves_path, SectorTree.SelectedNode.Text, "SANDBOX_0_0_0_.sbs");
                if (File.Exists(file))
                {
                    Sandbox.CommonLib.ObjectBuilders.MyObjectBuilder_Base sec = Sandbox.CommonLib.ObjectBuilders.MyObjectBuilder_Base.CreateNewObject(Sandbox.CommonLib.ObjectBuilders.MyObjectBuilderTypeEnum.Sector);
                    MyObjectBuilder_Sector mySector = (Sandbox.CommonLib.ObjectBuilders.MyObjectBuilder_Sector)sec;
                    Console.WriteLine(mySector.Position.ToString());
                    try
                    {
                        using (FileStream sr = File.Open(file, FileMode.Open))
                        {
                            if (Sandbox.CommonLib.ObjectBuilders.MyObjectBuilder_Base.DeserializeXML(sr, out mySector))
                            {
                                this.create_tree(SectorTree.SelectedNode, mySector);
                            }
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        MessageBox.Show("Unable to load that savegame, please report this!");
                    }
                }
            }
            
            //save sector
            private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Overwrite \"" + SectorTree.SelectedNode.Text + "\"?", "Save", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    string file = Path.Combine(this.saves_path, SectorTree.SelectedNode.Text, "SANDBOX_0_0_0_.sbs");
                    string backupfile = Path.Combine(this.saves_path, SectorTree.SelectedNode.Text, "SANDBOX_0_0_0_.BAK2");
                    if (File.Exists(backupfile))
                        File.Delete(backupfile);
                    File.Move(file, backupfile);                    
                    label1.Text = "Saving...";
                    MyObjectBuilder_Sector mySector = (MyObjectBuilder_Sector)SectorTree.SelectedNode.Tag;
                    using (FileStream sr = File.Open(file, FileMode.Create))
                    {
                        MyObjectBuilder_Base.SerializeXML(sr, mySector);
                        sr.Dispose();
                    }
                    
                    label1.Text = "";
                }
            }
            


            private void makeCopyToolStripMenuItem_Click(object sender, EventArgs e)
            {
                String savegame = "";
                DialogResult result = Form1.InputBox("Copy SaveGame", "Enter the name of the new savegame", ref savegame);
                if (result == DialogResult.OK && savegame != "")
                {
                    String oldpath = Path.Combine(this.saves_path, SectorTree.SelectedNode.Text);
                    String newpath = Path.Combine(this.saves_path, savegame);
                    if (!Directory.Exists(newpath))
                    {
                        Directory.CreateDirectory(newpath);
                    }
                    foreach (String file in Directory.GetFiles(oldpath))
                    {
                        String filename = file.Split(Path.DirectorySeparatorChar).Last();
                        String new_file = Path.Combine(newpath, filename);
                        File.Copy(file, new_file, true);
                    }
                    SectorTree.Nodes.Add(savegame);
                }
            }

            private void importShipToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                DialogResult result = fileopen.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filename = fileopen.FileName;
                    MyObjectBuilder_CubeGrid MyCubeGrid = (MyObjectBuilder_CubeGrid)MyObjectBuilder_Base.CreateNewObject(MyObjectBuilderTypeEnum.CubeGrid);                    
                    using (FileStream sr = File.Open(filename, FileMode.Open))
                    {
                        if (Sandbox.CommonLib.ObjectBuilders.MyObjectBuilder_Base.DeserializeXML(sr, out MyCubeGrid))
                        {
                            TreeNode savegame_node = SectorTree.SelectedNode;
                            MyObjectBuilder_Sector mySector = (MyObjectBuilder_Sector)savegame_node.Tag;
                            mySector.SectorObjects.Add(MyCubeGrid);
                            this.create_tree(savegame_node, mySector);
                        }
                    }

                }
            }

            public static long generate_new_id()
            {               
                long min = long.MinValue;
                long max = long.MaxValue;
                ulong uRange = (ulong)(max - min);
                ulong ulongRand;
                do
                {
                    byte[] buf = new byte[8];
                    rnd.NextBytes(buf);
                    ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
                } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);
                long result = (long)(ulongRand % uRange) + min;
                return result;
            }

            private void regenerateIDs(MyObjectBuilder_CubeGrid mg)
            {
                mg.EntityId = Form1.generate_new_id();
                foreach (MyObjectBuilder_CubeBlock cb in mg.CubeBlocks)
                {
                    cb.EntityId = Form1.generate_new_id();
                }
            }

            private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
            {
                TreeNode node = SectorTree.SelectedNode;
                MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                if (myBase.GetObjectBuilderTypeId() == MyObjectBuilderTypeEnum.CubeGrid)
                {
                    MyObjectBuilder_CubeGrid myGrid = (MyObjectBuilder_CubeGrid)myBase;
                    TreeNode SectorNode = node.Parent.Parent;
                    MyObjectBuilder_Sector mySector = (MyObjectBuilder_Sector)SectorNode.Tag;
                    Console.WriteLine(mySector.SectorObjects.Count());
                    mySector.SectorObjects.Remove(myGrid);
                    mySector.SectorObjects.TrimExcess();
                    Console.WriteLine(mySector.SectorObjects.Count());
                    node.Remove();
                }
            }

            private void moveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                TreeNode node = SectorTree.SelectedNode;
                MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                if (myBase.GetObjectBuilderTypeId() == MyObjectBuilderTypeEnum.CubeGrid)
                {
                    MyObjectBuilder_CubeGrid myGrid = (MyObjectBuilder_CubeGrid)myBase;
                    Form2 newform = new Form2(this);
                    MyPositionAndOrientation pos = (MyPositionAndOrientation)myGrid.PositionAndOrientation;
                    newform.Show();
                    newform.setVals(pos.Position.X, pos.Position.Y, pos.Position.Z);
                }
            }

            public void setPosition(float x, float y, float z)
            {
                TreeNode node = SectorTree.SelectedNode;
                MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                if (myBase.GetObjectBuilderTypeId() == MyObjectBuilderTypeEnum.CubeGrid)
                {
                    MyObjectBuilder_CubeGrid myGrid = (MyObjectBuilder_CubeGrid)myBase;
                    MyPositionAndOrientation pos = (MyPositionAndOrientation)myGrid.PositionAndOrientation;
                    pos.Position.X = x;
                    pos.Position.Y = y;
                    pos.Position.Z = z;
                    myGrid.PositionAndOrientation = pos;
                }
            }

            private void regenerateIDsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                 TreeNode node = SectorTree.SelectedNode;
                MyObjectBuilder_Base myBase = (MyObjectBuilder_Base)node.Tag;
                if (myBase.GetObjectBuilderTypeId() == MyObjectBuilderTypeEnum.CubeGrid)
                {
                    MyObjectBuilder_CubeGrid myGrid = (MyObjectBuilder_CubeGrid)myBase;
                    this.regenerateIDs(myGrid);
                }


            }

      




        }




    

       
    }

