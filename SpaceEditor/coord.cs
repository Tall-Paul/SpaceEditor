using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace SpaceEditor
{
    class coord
    {
        public float X = 0;
        public float Y = 0;
        public float Z = -999;
        public float W = -999;

        public void loadFromXML(XmlNode node)
        {
            this.X = float.Parse(node.SelectSingleNode("X").InnerText);
            this.Y = float.Parse(node.SelectSingleNode("Y").InnerText);

            XmlNode Znode = node.SelectSingleNode("Z");
            if (Znode != null && !string.IsNullOrEmpty(Znode.InnerText))
                this.Z = float.Parse(Znode.InnerText);

            XmlNode Wnode = node.SelectSingleNode("W");
            if (Wnode != null && !string.IsNullOrEmpty(Wnode.InnerText))
                this.W = float.Parse(Wnode.InnerText);
        }

        public TreeNode getTreeNode(string nodename){
            TreeNode node =  new TreeNode(nodename);
            node.Nodes.Add(new TreeNode("[X]"+this.X.ToString()));
            node.Nodes.Add(new TreeNode("[Y]"+this.Y.ToString()));
            node.Nodes.Add(new TreeNode("[Z]"+this.Z.ToString()));
            node.Nodes.Add(new TreeNode("[W]" + this.W.ToString()));
            node.Tag = this;
            return node;
            
        }

        public string getXML(string nodename)
        {
            string xml = "<" + nodename + ">\r\n";
            xml += "<X>" + this.X.ToString() + "</X>\r\n";
            xml += "<Y>" + this.Y.ToString() + "</Y>\r\n";
            if (this.Z != -999)
            {
                xml += "<Z>" + this.Z.ToString() + "</Z>\r\n";
            }
            if (this.W != -999)
            {
                xml += "<W>" + this.W.ToString() + "</W>\r\n";
            }
            xml += "</" + nodename + ">\r\n";
            return xml;
        }



    }
}
