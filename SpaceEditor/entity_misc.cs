using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SpaceEditor
{
    class entity_misc : EntityBase
    {
        public string xml;  
      
        public entity_misc(Sector parent) : base(parent) { }

        public void loadFromXML(XmlNode node)
        {
            base.loadFromXML(node);
            this.xml = node.InnerXml.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"","");                  
        }

        public string getXML()
        {
            string outxml = "<MyObjectBuilder_EntityBase xsi:type=\"MyObjectBuilder_Character\">";
            outxml += this.xml;
            outxml += "</MyObjectBuilder_EntityBase>";
            return outxml;
        }

    }
}
