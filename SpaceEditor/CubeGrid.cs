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
                new_block.loadFromXML(block);
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

        public CubeBlock loadXMLFragment(string xml,Random rnd)
        {
            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
            XmlReaderSettings xset = new XmlReaderSettings();
            xset.ConformanceLevel = ConformanceLevel.Fragment;
            XmlReader rd = XmlReader.Create(new StringReader(xml), xset, context);
            XmlDocument NewDoc = new XmlDocument();
            NewDoc.Load(rd);
            CubeBlock cb = new CubeBlock();
            cb.loadFromXML(NewDoc.SelectSingleNode("MyObjectBuilder_CubeBlock"));
            cb.new_id(rnd);
            return cb;
        }

        public void mirror(string axis,Random rnd)
        {
            List<CubeBlock> NewCubeBlocks = new List<CubeBlock>();
            foreach (CubeBlock cb in CubeBlocks)
            {
                CubeBlock new_cb = this.loadXMLFragment(cb.getXML(), rnd);
                switch (axis)
                {
                    case "X":
                        new_cb.PositionAndOrientation.position.X = -new_cb.PositionAndOrientation.position.X;
                    break;
                    case "Y":
                        new_cb.PositionAndOrientation.position.Y = -new_cb.PositionAndOrientation.position.Y;
                    break;
                    case "Z":
                         new_cb.PositionAndOrientation.position.Z = -new_cb.PositionAndOrientation.position.Z;
                    break;
                }
                NewCubeBlocks.Add(new_cb);
            }
            CubeBlocks.AddRange(NewCubeBlocks);
        }

    }
}
