using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace SpaceEditor
{
    class Sector
    {
        public coord Position = new coord();
        public List<CubeGrid> CubeGrids = new List<CubeGrid>();
        public List<VoxelMap> VoxelMaps = new List<VoxelMap>();
        public List<entity_misc> EntityMiscs = new List<entity_misc>();
        private XmlDocument doc = new XmlDocument();
        public Random rnd = new Random();
        
        private TreeNode vm_nodes = new TreeNode("Asteroids / Moons");
        private TreeNode cg_nodes = new TreeNode("Ships / stations");
        private TreeNode misc_nodes = new TreeNode("Other");

        public Character character = new Character();

        public void loadCGFragment(string xml,bool displace = false)
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
            new_cg.loadFromXML(NewDoc.SelectSingleNode("MyObjectBuilder_EntityBase"));
            new_cg.new_id(rnd);
            if (displace == true)
                new_cg.PositionAndOrientation.position.Y += 50;
            this.CubeGrids.Add(new_cg);
        }

        public void loadFromXML(string filename){
            Console.WriteLine("Loading sector from " + filename);
             doc.Load(filename); 
             try
                    {  
                    XmlNode SectorPosition = doc.DocumentElement.SelectSingleNode("/MyObjectBuilder_Sector/Position");
                    this.Position.loadFromXML(SectorPosition);
                    XmlNodeList SectorObjects = doc.DocumentElement.SelectNodes("/MyObjectBuilder_Sector/SectorObjects/MyObjectBuilder_EntityBase");
                    foreach(XmlNode entity in SectorObjects){                        
                        string entity_type = entity.Attributes["xsi:type"].Value;                        
                        switch (entity_type)
                        {
                            case "MyObjectBuilder_VoxelMap":                                
                                VoxelMap vm = new VoxelMap();
                                vm.loadFromXML(entity);
                                this.VoxelMaps.Add(vm);                                                              
                                break;
                            case "MyObjectBuilder_CubeGrid":
                                CubeGrid cg = new CubeGrid();
                                cg.loadFromXML(entity);
                                this.CubeGrids.Add(cg);                                
                                break;
                            case "MyObjectBuilder_Character":
                                character.loadFromXML(entity, "sector");
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
                    
                }

             if (character.parent == "")
             {
                 this.CubeGrids.Clear();
                 this.VoxelMaps.Clear();
                 this.EntityMiscs.Clear();
                 MessageBox.Show("Unable to load world, Are you currently piloting a ship?");
                 
             }

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
