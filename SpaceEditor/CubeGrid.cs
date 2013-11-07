using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace SpaceEditor
{
    class CubeGrid : EntityBase
    {
        public List<CubeBlock> CubeBlocks = new List<CubeBlock>();
        public string GridSizeEnum;
        public CubeBlock cockpit = null;
        public String IsStatic = "false";
        public coord LinearVelocity = new coord();
        public coord AngularVelocity = new coord();
        public bool hasPilot = false;
        public Character Pilot = null;
        public string raw = "";
        public bool dirty = false;
        public bool quick_loaded = false;
        public int quick_count = 0;
        

        public void loadFromXML(XmlNode node, bool quick = false)
        {            
            base.loadFromXML(node);
            this.GridSizeEnum = node.SelectSingleNode("GridSizeEnum").InnerText;
            this.quick_loaded = quick;
            XmlNodeList blocks = node.SelectNodes("CubeBlocks/MyObjectBuilder_CubeBlock");
            if (quick == false)
            {
                Console.WriteLine("Loading blocks...");
                foreach (XmlNode block in blocks)
                {
                    CubeBlock new_block = new CubeBlock();
                    new_block.loadFromXML(block);
                    if (new_block.SubTypeName == "LargeBlockCockpit" || new_block.SubTypeName == "SmallBlockCockpit")
                    {
                        this.cockpit = new_block;
                        if (new_block.hasPilot == true)
                        {
                            this.hasPilot = true;
                            new_block.Pilot.parent = this.EntityId;
                            Pilot = new_block.Pilot;
                        }
                    }
                    CubeBlocks.Add(new_block);
                }
            }
            else
            {
                this.raw = node.SelectSingleNode("CubeBlocks").OuterXml;
                Console.WriteLine("Quick loaded");
                this.quick_count = blocks.Count;
            }
            try
            {
                IsStatic = node.SelectSingleNode("IsStatic").InnerText;            
                LinearVelocity.loadFromXML(node.SelectSingleNode("LinearVelocity"));
                AngularVelocity.loadFromXML(node.SelectSingleNode("AngularVelocity"));
            }
            catch (NullReferenceException) { }
            if (this.GridSizeEnum == "Large")
                if (this.IsStatic == "true")
                    this.displayType = "Station";
                else
                    this.displayType = "Large Ship";
            if (this.GridSizeEnum == "Small")
                this.displayType = "Small Ship";
            if (this.hasPilot == true)
            {
                this.displayType = "[*] " + this.displayType;
            }
            this.actualType = "Ship";             
            Console.WriteLine("Loaded");
            //Console.WriteLine("Loaded "+displayType+" with "+CubeBlocks.Count +" blocks");
        }

        public int getBlockcount()
        {
            if (quick_loaded == true)
                return this.quick_count;
            else
                return CubeBlocks.Count();

        }

        /*
         * not working yet
         * 
         */
        public Bitmap getThumbnail(){
            float biggest_x =  0;
            float smallest_x = 0;
            float biggest_y = 0;
            float smallest_y = 0;
            int offset_x = 0;
            int offset_y = 0;
            foreach (CubeBlock cb in CubeBlocks)
            {
                float x = (float)cb.PositionAndOrientation.position.Y;
                float y = (float)cb.PositionAndOrientation.position.Z;
                if (x > biggest_x)
                    biggest_x = x;
                if (x < smallest_x)
                    smallest_x = x;
                if (y > biggest_y)
                    biggest_y = y;
                if (y < smallest_y)
                    smallest_y = y;                
            }
            Console.WriteLine("Original X Range: " + smallest_x + ":" + biggest_x);
            Console.WriteLine("Original Y Range: " + smallest_y + ":" + biggest_y);
            offset_x = (int)(0-smallest_x);
            offset_y = (int)(0-smallest_y);
            
            smallest_x = 0;
            smallest_y = 0;            
            float scale = 1;
            if (this.GridSizeEnum == "Large")
                scale = (float)2.5;
            biggest_x = ((biggest_x + offset_x) / scale)+1;
            biggest_y = ((biggest_y + offset_y) / scale)+1;
            offset_x = (int)(offset_x / scale);
            offset_y = (int)(offset_y / scale);
            Console.WriteLine(offset_x);
            Console.WriteLine(offset_y);
            Console.WriteLine("Offset and scaled X Range: " + smallest_x + ":" + (int)biggest_x);
            Console.WriteLine("Offset and scaled Y Range: " + smallest_y + ":" + (int)biggest_y);
            Bitmap thumbnail = new Bitmap((int)biggest_x, (int)biggest_y);            
            foreach (CubeBlock cb in CubeBlocks)
            {
                int x = 0;
                int y = 0;
                //if ((float)cb.PositionAndOrientation.position.X > 0)
                    x = (int)((float)cb.PositionAndOrientation.position.Y / scale) + offset_x;
                //else
                   // x = 0;
                    //x = (int)((float)-cb.PositionAndOrientation.position.X / scale) + offset_x;
                //if ((float)cb.PositionAndOrientation.position.Y > 0)
                    y = (int)((float)cb.PositionAndOrientation.position.Z / scale) + offset_y;
                //else
                    //y = (int)((float)-cb.PositionAndOrientation.position.Y / scale) + offset_y;
                    //y = 0;
                try
                {
                    thumbnail.SetPixel(x, y, Color.Black);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("X: " + x + " Y: " + y);
                }               
                
            }
            float ratio = biggest_x / 500;
            int fullsize_x = 500;            
            int fullsize_y = (int)(biggest_y / ratio);
            Bitmap fullsize = new Bitmap(fullsize_x, fullsize_y);
            using (Graphics g = Graphics.FromImage((Image)fullsize))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(thumbnail, 0, 0, fullsize_x, fullsize_y);
            }
            return fullsize;
        }

        public TreeNode getTreeNode()
        {
            TreeNode node = base.getTreeNode();
            if (quick_loaded == false)
            {
                if (cockpit != null)
                    node.Nodes.Add("[cockpit] " + cockpit.EntityId);
                node.Nodes.Add("[blockCount] " + CubeBlocks.Count());
                CubeBlock attachmentPoint = this.getBlock("LargeBlockArmorSlopeWhite");
                if (attachmentPoint != null)
                {
                    TreeNode block = new TreeNode(attachmentPoint.SubTypeName);
                    block.Nodes.Add("Up " + attachmentPoint.PositionAndOrientation.up.ToString());
                    block.Nodes.Add("Forward " + attachmentPoint.PositionAndOrientation.forward.ToString());
                    block.Nodes.Add("Orientation " + attachmentPoint.Orientation.ToString());
                    node.Nodes.Add(block);
                }
            }
            else
            {
                node.Nodes.Add("[blockCount] " + this.quick_count);
            }
            node.Tag = this;
            return node;
        }

        public string getXML()
        {
            if (quick_loaded == true)
            {
                string xml = "<MyObjectBuilder_EntityBase xsi:type='MyObjectBuilder_CubeGrid'>\r\n";
                xml += base.getXML();
                xml += "<GridSizeEnum>" + this.GridSizeEnum + "</GridSizeEnum>\r\n";
                xml += this.raw;
                xml += "<IsStatic>" + IsStatic + "</IsStatic>";
                xml += LinearVelocity.getXML("LinearVelocity");
                xml += AngularVelocity.getXML("AngularVelocity");
                xml += "</MyObjectBuilder_EntityBase>\r\n";
                return xml;
            }
            else
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
                xml += "<IsStatic>" + IsStatic + "</IsStatic>";
                xml += LinearVelocity.getXML("LinearVelocity");
                xml += AngularVelocity.getXML("AngularVelocity");
                xml += "</MyObjectBuilder_EntityBase>\r\n";               
                return xml;
            }
        }

        public void new_id()
        {
            base.new_id();
            if (this.quick_loaded == false)
            {
                
                foreach (CubeBlock block in this.CubeBlocks)
                {
                    block.new_id();
                }
            }
            else
            {
                Console.WriteLine("Doing replacement");
                Regex rgex = new Regex(@"<EntityId>\s*(.+?)\s*</EntityId>");
                this.raw = rgex.Replace(this.raw,new MatchEvaluator(EntityBase.replace_id));                
            }
        }

        public CubeBlock loadXMLFragment(string xml)
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
            cb.new_id();
            return cb;
        }

        public void mirror(string axis)
        {
            List<CubeBlock> NewCubeBlocks = new List<CubeBlock>();
            foreach (CubeBlock cb in CubeBlocks)
            {
                CubeBlock new_cb = this.loadXMLFragment(cb.getXML());
                double newVal = 0;
                switch (axis)
                {
                    case "X":                        
                        new_cb.PositionAndOrientation.position.X = -new_cb.PositionAndOrientation.position.X;
                        new_cb.Min.X = -new_cb.Min.X;
                        new_cb.Max.X = -new_cb.Max.X;
                        newVal = new_cb.PositionAndOrientation.position.X;
                    break;
                    case "Y":
                        new_cb.PositionAndOrientation.position.Y = -new_cb.PositionAndOrientation.position.Y;
                         new_cb.Min.Y = -new_cb.Min.Y;
                        new_cb.Max.Y = -new_cb.Max.Y;
                        newVal = new_cb.PositionAndOrientation.position.Y;
                    break;
                    case "Z":                        
                         new_cb.PositionAndOrientation.position.Z = -new_cb.PositionAndOrientation.position.Z;
                         new_cb.Min.Z = -new_cb.Min.Z;
                        new_cb.Max.Z = -new_cb.Max.Z;
                         newVal = new_cb.PositionAndOrientation.position.Z;
                    break;
                }
                if (newVal != -0)
                    NewCubeBlocks.Add(new_cb);
            }
            this.CubeBlocks.AddRange(NewCubeBlocks);
        }

        public CubeBlock getBlock(string SubTypeName)
        {
            foreach (CubeBlock cb in CubeBlocks)
            {
                Console.WriteLine(cb.SubTypeName);
                if (cb.SubTypeName == SubTypeName)
                    return cb;
            }
            return null;
        }

        public void reOrient(PandO offset_pando, coord offset_min, coord offset_max){
            this.dirty = true;
            foreach (CubeBlock cb in CubeBlocks)
            {
                cb.PositionAndOrientation.position.offset(offset_pando.position);
                cb.Min.offset(offset_min);
                cb.Max.offset(offset_max);
            }
        }

        public void reOrient(CubeBlock new_anchor)
        {
            this.dirty = true;
            reOrient(new_anchor.PositionAndOrientation.clone(), new_anchor.Min.clone(), new_anchor.Max.clone());
        }

        public void merge(CubeGrid newGrid)
        {
            this.dirty = true;
            foreach (CubeBlock cb in newGrid.CubeBlocks)
            {
                if (!cb.isAnchor())
                    this.CubeBlocks.Add(cb);
            }
        }

        public void rotate_grid(string axis, int steps)
        {
            this.dirty = true;
            Console.WriteLine("################## Rotate " + axis + " " + steps+ "##########################");
            if (steps == 0)
                return;
            foreach (CubeBlock cb in CubeBlocks)
            {
                Console.WriteLine("Rotating " + cb.SubTypeName);
                cb.PositionAndOrientation.rotate_grid(axis, steps);
                cb.Min.rotate_grid(axis, steps);
                cb.Max.rotate_grid(axis, steps);
                cb.Orientation.rotate_grid(axis, steps);
            }
        }

    }
}
