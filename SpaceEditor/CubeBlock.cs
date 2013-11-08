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
        public bool hasPilot = false;
        public Character Pilot = null;

        public CubeBlock(Sector parent) : base(parent) { }

        public void loadFromXML(XmlNode node)
        {
            base.loadFromXML(node);
            this.SubTypeName = node.SelectSingleNode("SubtypeName").InnerText;
            //Console.WriteLine("loaded " + this.SubTypeName);
            this.Min.loadFromXML(node.SelectSingleNode("Min"));
            this.Max.loadFromXML(node.SelectSingleNode("Max"));
            this.Orientation.loadFromXML(node.SelectSingleNode("Orientation"));
            XmlNode myPilot = node.SelectSingleNode("Pilot");
            if (myPilot != null)
            {
                this.hasPilot = true;
                Console.WriteLine("Got pilot");
                Pilot = new Character(this.parent_sector);
                Pilot.loadFromXML(myPilot,this.EntityId);
            }
            this.displayType = this.SubTypeName;
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
            if (this.hasPilot == true)
            {
                xml += this.Pilot.getXML();
            }
            xml += "</MyObjectBuilder_CubeBlock>\r\n";
            
            return xml;
        }

        public bool isAnchor()
        {
            return this.PositionAndOrientation.isZero();
        }

       


    
  
    }
}
