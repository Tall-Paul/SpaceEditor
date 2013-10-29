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
            TreeNode xnode = new TreeNode(this.X.ToString());
            xnode.Tag = "X";
            node.Nodes.Add(xnode);


            TreeNode ynode = new TreeNode(this.Y.ToString());
            ynode.Tag = "Y";
            node.Nodes.Add(ynode);

            TreeNode znode = new TreeNode(this.Z.ToString());
            znode.Tag = "Z";
            node.Nodes.Add(znode);

            TreeNode wnode = new TreeNode(this.W.ToString());
            wnode.Tag = "W";
            node.Nodes.Add(wnode);
               
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

        public void setValue(string key, string value)
        {
            Console.WriteLine("setvalue called: " + key + " | " + value);
            float newValue = 0;
            if (float.TryParse(value,out newValue)){
                switch (key)
                {
                    case "X":
                        X = newValue;
                        break;
                    case "Y":
                        Y = newValue;
                        break;
                    case "Z":
                        Z = newValue;
                        break;
                    case "W":
                        W = newValue;
                        break;
                }
            }
            
        }



    }
}
