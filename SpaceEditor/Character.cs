using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace SpaceEditor
{
    class Character : EntityBase
    {
        public string parent = ""; //either 'sector' or entity id of the cockpit this character is controlling
        public string CharacterModel = "";
        public string Inventory = ""; //we don't parse this yet
        public string Battery = ""; //nor this
        public string LightEnabled = ""; //true or false
        public string JetpackMode = "";
        public string UsingLadder = "";
        public coord HeadAngle = new coord();
        public coord LinearVelocity = new coord();
        public string AutoenableJetPackDelay = "0";

        public Character(Sector parent) : base(parent) { }

        public void loadFromXML(XmlNode node, string parent_string)
        {
           
            base.loadFromXML(node);
            Console.WriteLine("loading character");
            Console.WriteLine(parent_string);
            this.parent = parent_string;            
            this.displayType = "Character";
            this.actualType = "Character";           
            CharacterModel = node.SelectSingleNode("CharacterModel").InnerText;
            Console.WriteLine("got model");
            Inventory = node.SelectSingleNode("Inventory").InnerXml;
            Console.WriteLine("got inventory");
            Battery = node.SelectSingleNode("Battery").InnerXml;
            Console.WriteLine("got battery");
            LightEnabled = node.SelectSingleNode("LightEnabled").InnerText;
            Console.WriteLine("got light");
            JetpackMode = node.SelectSingleNode("JetpackMode").InnerText;            
            XmlNode trynode = node.SelectSingleNode("HeadAngle");
            if (trynode != null)
                HeadAngle.loadFromXML(trynode);
            trynode = node.SelectSingleNode("LinearVelocity");
            if (trynode != null)
                LinearVelocity.loadFromXML(trynode);
            trynode = node.SelectSingleNode("AutoenableJetpackDelay");
            if (trynode != null)
                AutoenableJetPackDelay = trynode.InnerText;            
            Console.WriteLine("Character Loaded");
        }

        public TreeNode getTreeNode()
        {
            TreeNode node = base.getTreeNode();
            node.Nodes.Add("[parent] " + parent);
            node.Nodes.Add("[CharacterModel] " + CharacterModel);
            return node;
        }

        public string getXML()
        {
            string xml = "";
            if (parent == "sector")
                xml += "<MyObjectBuilder_EntityBase xsi:type=\"MyObjectBuilder_Character\">\r\n";
            else
                xml += "<Pilot>\r\n";
            xml += base.getXML();
            xml += "<CharacterModel>" + CharacterModel + "</CharacterModel>\r\n";
            xml += "<Inventory>" + Inventory + "</Inventory>\r\n";
            xml += "<Battery>" + Battery + "</Battery>\r\n";
            xml += "<LightEnabled>" + LightEnabled + "</LightEnabled>\r\n";
            xml += "<JetpackMode>" + JetpackMode + "</JetpackMode>\r\n";
            xml += "<UsingLadder xsi:nil=\"true\" />\r\n";
            xml += HeadAngle.getXML("HeadAngle");
            xml += LinearVelocity.getXML("LinearVelocity");
            if (parent == "sector")
                xml += "</MyObjectBuilder_EntityBase>\r\n";
            else
                xml += "</Pilot>\r\n";

            return xml;
        }
    }
}
