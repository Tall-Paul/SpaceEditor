using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;


namespace SpaceEditor
{
    class CubeBlock : EntityBase
    {
        public string SubTypeName;        
        public coord Min = new coord();
        public coord Max = new coord();
        public coord Orientation = new coord();

        public void loadFromXML(XmlNode node)
        {
            base.loadFromXML(node);
            this.SubTypeName = node.SelectSingleNode("SubtypeName").InnerText;
            Console.WriteLine("loaded " + this.SubTypeName);
            this.Min.loadFromXML(node.SelectSingleNode("Min"));
            this.Max.loadFromXML(node.SelectSingleNode("Max"));
            this.Orientation.loadFromXML(node.SelectSingleNode("Orientation"));
        }

        public string getXML()
        {
            string xml = "";
            xml += "<MyObjectBuilder_CubeBlock";
            if (this.XMLType != null)
                xml += " xsi:type=\""+this.XMLType+"\"";
            xml += ">\r\n";
            xml += "<SubtypeName>"+this.SubTypeName+"</SubtypeName>\r\n";
            xml += base.getXML();
            xml += this.Min.getXML("Min");
            xml += this.Max.getXML("Max");
            xml += this.Orientation.getXML("Orientation");
            xml += "</MyObjectBuilder_CubeBlock>\r\n";
            return xml;
        }

       


    
  
    }
}
