using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace SpaceEditor
{
    class VoxelMap : EntityBase
    {
        public string Filename;

        public VoxelMap(Sector parent) : base(parent) { }

        public void loadFromXML(XmlNode node)
        {
            base.loadFromXML(node);
            this.Filename = node.SelectSingleNode("Filename").InnerText;
            this.displayType = "Asteroid";
        }

        public TreeNode getTreeNode()
        {
            TreeNode node = base.getTreeNode();
            node.Nodes.Add("[Filename] " + this.Filename);
            return node;
        }

        public string getXML()
        {
            string xml = "<MyObjectBuilder_EntityBase xsi:type='MyObjectBuilder_VoxelMap'>\r\n";
            xml += base.getXML();
            xml += "<Filename>" + this.Filename + "</Filename>";
            xml += "</MyObjectBuilder_EntityBase>\r\n";
            return xml;
        }
    }
}
