using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace SpaceEditor
{
    class CubeGrid : EntityBase
    {
        public List<CubeBlock> CubeBlocks = new List<CubeBlock>();
        public string GridSizeEnum;
        public CubeBlock cockpit = null;

        public void loadFromXML(XmlNode node)
        {
            base.loadFromXML(node);
            this.GridSizeEnum = node.SelectSingleNode("GridSizeEnum").InnerText;
            XmlNodeList blocks = node.SelectNodes("CubeBlocks/MyObjectBuilder_CubeBlock");            
            foreach (XmlNode block in blocks)
            {
                CubeBlock new_block = new CubeBlock();
                new_block.loadFromXml(block);
                if (new_block.SubTypeName == "LargeBlockCockpit" || new_block.SubTypeName == "SmallBlockCockpit")
                    this.cockpit = new_block;
                CubeBlocks.Add(new_block);
            }
            if (this.GridSizeEnum == "Large")
                this.displayType = "Large Ship";
            if (this.GridSizeEnum == "Small")
                this.displayType = "Small Ship";
            this.actualType = "Ship";
            //not sure what happens with stations, need to check
        }

        public TreeNode getTreeNode()
        {
            TreeNode node = base.getTreeNode();
            if (cockpit != null)
                node.Nodes.Add("[cockpit] " + cockpit.EntityId);
            node.Nodes.Add("[blockCount] " + CubeBlocks.Count());
            node.Tag = this;
            return node;
        }

        public string getXML()
        {
            string xml = "<MyObjectBuilder_EntityBase xsi:type='MyObjectBuilder_CubeGrid'>\r\n";
            xml += base.getXML();
            xml += "<GridSizeEnum>" + this.GridSizeEnum + "</GridSizeEnum>\r\n";
            xml += "<CubeBlocks>\r\n";
            foreach (CubeBlock block in this.CubeBlocks)
            {
                xml += block.getXML();
            }
            xml += "</CubeBlocks>\r\n";
            xml += "</MyObjectBuilder_EntityBase>\r\n";
            return xml;
        }

        public void new_id(Random rnd)
        {
            base.new_id(rnd);
            foreach (CubeBlock block in this.CubeBlocks)
            {
                block.new_id(rnd);
            }
        }

    }
}
