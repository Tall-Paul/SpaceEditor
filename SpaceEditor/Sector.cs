using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Media3D;

namespace SpaceEditor
{
    class Sector
    {
        public coord Position = new coord();
        public List<CubeGrid> CubeGrids = new List<CubeGrid>();
        public List<VoxelMap> VoxelMaps = new List<VoxelMap>();
        public List<entity_misc> EntityMiscs = new List<entity_misc>();
        private XmlDocument doc = new XmlDocument();
        public static Random rnd = new Random();
        
        private TreeNode vm_nodes = new TreeNode("Asteroids / Moons");
        private TreeNode cg_nodes = new TreeNode("Ships / stations");
        private TreeNode misc_nodes = new TreeNode("Other");

        public Character character = new Character();

        public bool quick_loaded = false;

       

        public static Vector3D diff_orientation(CubeBlock block1, CubeBlock block2)
        {
            Quaternion orientation_1 = new Quaternion(block1.Orientation.X, block1.Orientation.Y, block1.Orientation.Z, block1.Orientation.W);
            Quaternion orientation_2 = new Quaternion(block2.Orientation.X, block2.Orientation.Y, block2.Orientation.Z, block2.Orientation.W);
            orientation_2.Invert();
            Quaternion q = orientation_1 * orientation_2;
            return coord.quat_to_radians(q);            
        }

        public CubeGrid loadCGFragment(string xml,bool displace = false)
        {
            //have to jump through some hoops here to load our fragment
            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
            XmlReaderSettings xset = new XmlReaderSettings();
            xset.ConformanceLevel = ConformanceLevel.Fragment;
            XmlReader rd = XmlReader.Create(new StringReader(xml), xset, context);
            XmlDocument NewDoc = new XmlDocument();
            NewDoc.Load(rd);            
            CubeGrid new_cg = new CubeGrid();
            new_cg.loadFromXML(NewDoc.SelectSingleNode("MyObjectBuilder_EntityBase"),this.quick_loaded);
            new_cg.new_id();
            if (displace == true)
            {
                new_cg.PositionAndOrientation.position.Y += 50;
            }
            return new_cg;            
        }

        public String loadFromXML(string filename,bool loggingEnabled = false, bool quick_load = false){
            String log = "";
            this.quick_loaded = quick_load;

            log += "Loading Sector from " + filename + "\r\n";
             doc.Load(filename); 
             try
                    {  
                    XmlNode SectorPosition = doc.DocumentElement.SelectSingleNode("/MyObjectBuilder_Sector/Position");
                    this.Position.loadFromXML(SectorPosition);
                    log += "Got Sector Position\r\n";
                    XmlNodeList SectorObjects = doc.DocumentElement.SelectNodes("/MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase");
                    log += "Got Sector Objects\r\n";
                    foreach(XmlNode entity in SectorObjects){                        
                        string entity_type = entity.Attributes["xsi:type"].Value;                        
                        switch (entity_type)
                        {
                            case "MyObjectBuilder_VoxelMap":                                
                                VoxelMap vm = new VoxelMap();
                                log += "Loading VoxelMap\r\n";
                                try
                                {
                                    vm.loadFromXML(entity);
                                    log += "VoxelMap " + vm.Filename + " Loaded\r\n";
                                    this.VoxelMaps.Add(vm);
                                }
                                catch (Exception err)
                                {
                                    log += "Exception loading VoxelMap "+ err.Message +"\r\n";
                                }                        
                                break;
                            case "MyObjectBuilder_CubeGrid":
                                CubeGrid cg = new CubeGrid();
                                log += "Loading CubeGrid\r\n";
                                try
                                {
                                    cg.loadFromXML(entity,quick_load);
                                    log += cg.displayType + " with " + cg.CubeBlocks.Count() + "Blocks Loaded\r\n";
                                    if (cg.hasPilot == true)
                                    {
                                        this.character = cg.Pilot;
                                        log += "found Pilot\r\n";
                                    }
                                    this.CubeGrids.Add(cg);
                                }
                                catch (Exception err)
                                {
                                    log += "Exception loading CubeGrid " + err.Message + "\r\n";
                                }
                                break;
                            case "MyObjectBuilder_Character":
                                log += "Loading Character\r\n";
                                try
                                {
                                    character.loadFromXML(entity, "sector");
                                    log += "Character Loaded\r\n";
                                }
                                catch (Exception err)
                                {
                                    log += "Exception loading Character " + err.Message + "\r\n";
                                }
                                break;
                            default:
                                entity_misc em = new entity_misc();
                                em.loadFromXML(entity);
                                this.EntityMiscs.Add(em);
                                break;
                        }
                    }
                    
                    
                }
                catch (Exception err) {
                    log += "Exception! " + err.Message+" "+err.Source+"\r\n";
                    log += "StackTrace " + err.StackTrace+"\r\n";
                }

             if (character.parent == "")
             {
                 this.CubeGrids.Clear();
                 this.VoxelMaps.Clear();
                 this.EntityMiscs.Clear();
                 log += "No Character / Pilot found!!\r\n";
                 MessageBox.Show("Unable to load world, Are you currently piloting a ship?");                 
             }
             return log;

        }

        public TreeNode getTreeNode(){
            TreeNode SectorNode = new TreeNode("Sector " + this.Position.X.ToString() + "," + this.Position.Y.ToString() + "," + this.Position.Z.ToString());
            Console.WriteLine("Reloading CubeGrid nodes");
            if (character.parent != "")
                SectorNode.Nodes.Add(character.getTreeNode());
            if (CubeGrids.Count > 0)
            {
                cg_nodes = new TreeNode("Ships / stations");
                foreach (CubeGrid cg in CubeGrids)
                {
                    cg_nodes.Nodes.Add(cg.getTreeNode());
                }
                SectorNode.Nodes.Add(cg_nodes);
            }
            if (VoxelMaps.Count > 0)
            {
                Console.WriteLine("Reloading VoxelMap nodes");
                vm_nodes = new TreeNode("Asteroids / Moons");
                foreach (VoxelMap vm in VoxelMaps)
                {
                    vm_nodes.Nodes.Add(vm.getTreeNode());
                }
                SectorNode.Nodes.Add(vm_nodes);
            }
            return SectorNode;
        }

        public string getXML()
        {
            string xml = "<?xml version=\"1.0\"?>\r\n";
            xml += "<MyObjectBuilder_Sector xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n";
            xml += this.Position.getXML("Position");
            xml += "<SectorObjects>\r\n";
            foreach (VoxelMap vm in this.VoxelMaps)
            {
                xml += vm.getXML();
            }
            foreach (CubeGrid cg in this.CubeGrids)
            {
                xml += cg.getXML();
            }
            foreach (entity_misc em in this.EntityMiscs)
            {
                xml += em.getXML();
            }
            if (character.parent == "sector")
                xml += character.getXML();
            xml += "</SectorObjects>\r\n";
            xml += "</MyObjectBuilder_Sector>";
            return xml;
        }
    }
}
