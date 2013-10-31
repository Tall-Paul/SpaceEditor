using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;

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
            this.X = float.Parse(node.SelectSingleNode("X").InnerText, CultureInfo.InvariantCulture);
            this.Y = float.Parse(node.SelectSingleNode("Y").InnerText, CultureInfo.InvariantCulture);

            XmlNode Znode = node.SelectSingleNode("Z");
            if (Znode != null && !string.IsNullOrEmpty(Znode.InnerText))
                this.Z = float.Parse(Znode.InnerText, CultureInfo.InvariantCulture);

            XmlNode Wnode = node.SelectSingleNode("W");
            if (Wnode != null && !string.IsNullOrEmpty(Wnode.InnerText))
                this.W = float.Parse(Wnode.InnerText, CultureInfo.InvariantCulture);
        }

        public TreeNode getTreeNode(string nodename){
            TreeNode node =  new TreeNode(nodename);
            TreeNode xnode = new TreeNode(this.X.ToString(CultureInfo.InvariantCulture));
            xnode.Tag = "X";
            node.Nodes.Add(xnode);


            TreeNode ynode = new TreeNode(this.Y.ToString(CultureInfo.InvariantCulture));
            ynode.Tag = "Y";
            node.Nodes.Add(ynode);

            TreeNode znode = new TreeNode(this.Z.ToString(CultureInfo.InvariantCulture));
            znode.Tag = "Z";
            node.Nodes.Add(znode);

            TreeNode wnode = new TreeNode(this.W.ToString(CultureInfo.InvariantCulture));
            wnode.Tag = "W";
            node.Nodes.Add(wnode);
               
            node.Tag = this;
            return node;
            
        }

        public string getXML(string nodename)
        {
            string xml = "<" + nodename + ">\r\n";
            xml += "<X>" + this.X.ToString(CultureInfo.InvariantCulture) + "</X>\r\n";
            xml += "<Y>" + this.Y.ToString(CultureInfo.InvariantCulture) + "</Y>\r\n";
            if (this.Z != -999)
            {
                xml += "<Z>" + this.Z.ToString(CultureInfo.InvariantCulture) + "</Z>\r\n";
            }
            if (this.W != -999)
            {
                xml += "<W>" + this.W.ToString(CultureInfo.InvariantCulture) + "</W>\r\n";
            }
            xml += "</" + nodename + ">\r\n";
            return xml;
        }

        public void setValue(string key, string value)
        {
            Console.WriteLine("setvalue called: " + key + " | " + value);
            float newValue = 0;
            if (float.TryParse(value,NumberStyles.Float,CultureInfo.InvariantCulture, out newValue))
            {
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
