using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace SpaceEditor
{
    class coord
    {
        public double X = 0;
        public double Y = 0;
        public double Z = -999;
        public double W = -999;
        public bool quat;

        public void loadFromXML(XmlNode node)
        {
            this.X = double.Parse(node.SelectSingleNode("X").InnerText, CultureInfo.InvariantCulture);
            this.Y = double.Parse(node.SelectSingleNode("Y").InnerText, CultureInfo.InvariantCulture);

            XmlNode Znode = node.SelectSingleNode("Z");
            if (Znode != null && !string.IsNullOrEmpty(Znode.InnerText))
                this.Z = double.Parse(Znode.InnerText, CultureInfo.InvariantCulture);

            XmlNode Wnode = node.SelectSingleNode("W");
            if (Wnode != null && !string.IsNullOrEmpty(Wnode.InnerText))
            {
                this.W = double.Parse(Wnode.InnerText, CultureInfo.InvariantCulture);                
                this.quat = true;
                
            }
            else
            {
                this.quat = false;
            }            
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

            if (this.quat == true)
            {
                TreeNode wnode = new TreeNode(this.W.ToString(CultureInfo.InvariantCulture));
                wnode.Tag = "W";
                node.Nodes.Add(wnode);
            }               
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
            if (this.quat == true)
            {
                xml += "<W>" + this.W.ToString(CultureInfo.InvariantCulture) + "</W>\r\n";
            }
            xml += "</" + nodename + ">\r\n";
            return xml;
        }

        public double getValue(string key)
        {
            switch (key)
            {
                case "X":
                    return X;
                case "Y":
                    return Y;                    
                case "Z":
                    return Z;
                case "W":
                    return W;
                default: 
                    return 0;
            }
        }

        public void setValue(string key, string value)
        {            
            double newValue = 0;
            if (double.TryParse(value,NumberStyles.Float,CultureInfo.InvariantCulture, out newValue))
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

        

        public void setValue(string key, double newValue)
        {           
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

        public void offset(coord offset_coord)
        {
            
            this.X = this.X - offset_coord.X;
            this.Y = this.Y - offset_coord.Y;
            this.Z = this.Z - offset_coord.Z;
            
        }

        public bool isZero()
        {
            if (this.X == 0 && this.Y == 0 && this.Z == 0)
                return true;
            else
                return false;
        }

        public string ToString()
        {
            return this.X + "|" + this.Y + "|" + this.Z + "|"+  this.W;
        }

        public coord clone()
        {
            coord newClone = new coord();
            newClone.X = this.X;
            newClone.Y = this.Y;
            newClone.Z = this.Z;
            newClone.W = this.W;
            newClone.quat = this.quat;            
            return newClone;
        }

        public void rotate_grid(string axis, int steps=1){           
            if (this.quat == true)
                rotate_quat(axis, steps);
            else
                rotate_coord(axis, steps);
        }

        private double DegreesToRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }

        public static Vector3D quat_to_radians(Quaternion q)
        {
            // Store the Euler angles in radians
            Vector3D pitchYawRoll = new Vector3D();

            double sqw = q.W * q.W;
            double sqx = q.X * q.X;
            double sqy = q.Y * q.Y;
            double sqz = q.Z * q.Z;

            // If quaternion is normalised the unit is one, otherwise it is the correction factor
            double unit = sqx + sqy + sqz + sqw;
            double test = q.X * q.Y + q.Z * q.W;

            if (test > 0.4999f * unit)                              // 0.4999f OR 0.5f - EPSILON
            {
                // Singularity at north pole
                pitchYawRoll.Y = 2f * (float)Math.Atan2(q.X, q.W);  // Yaw
                pitchYawRoll.X = Math.PI * 0.5f;                         // Pitch
                pitchYawRoll.Z = 0f;                                // Roll
                return pitchYawRoll;
            }
            else if (test < -0.4999f * unit)                        // -0.4999f OR -0.5f + EPSILON
            {
                // Singularity at south pole
                pitchYawRoll.Y = -2f * (float)Math.Atan2(q.X, q.W); // Yaw
                pitchYawRoll.X = -Math.PI * 0.5f;                        // Pitch
                pitchYawRoll.Z = 0f;                                // Roll
                return pitchYawRoll;
            }
            else
            {
                pitchYawRoll.Y = (float)Math.Atan2(2f * q.Y * q.W - 2f * q.X * q.Z, sqx - sqy - sqz + sqw);       // Yaw
                pitchYawRoll.X = (float)Math.Asin(2f * test / unit);                                             // Pitch
                pitchYawRoll.Z = (float)Math.Atan2(2f * q.X * q.W - 2f * q.Y * q.Z, -sqx + sqy - sqz + sqw);      // Roll
            }

            return pitchYawRoll;
        }

        public static double RadianToDegrees(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static int RadianToSteps(double angle)
        {
            double actual_angle = angle * (180.0 / Math.PI); //converts to degrees
            //Console.WriteLine("Angle: " + actual_angle);
            //normalise
            //this was written on 1 hours sleep.  May be rubbish.
            if (actual_angle >= -271 && actual_angle < -181)
                return 1;
            if (actual_angle >= -181 && actual_angle < -91)
                return 2;
            if (actual_angle >= -91 && actual_angle < 0)
                return 3;
            if (actual_angle >= 0 && actual_angle < 90)
                return 0;
            if (actual_angle >= 90 && actual_angle < 180)
                return 1;
            if (actual_angle >= 180 && actual_angle < 270)
                return 2;
            if (actual_angle >= 270 && actual_angle < 360)
                return 3;
            return 0;

        }

        public void rotate_quat(string axis,int steps=1){                        
            Quaternion quat = new Quaternion(X,Y,Z,W);
            Console.WriteLine("Old Y: " + coord.RadianToDegrees(coord.quat_to_radians(quat).Y));
            Console.WriteLine("Old X: " + coord.RadianToDegrees(coord.quat_to_radians(quat).X));
            Console.WriteLine("Old Z: " + coord.RadianToDegrees(coord.quat_to_radians(quat).Z));            
            Vector3D rotate_axis = new Vector3D(0,0,0);
            switch (axis){
                case ("X"):
                    rotate_axis = new Vector3D(0,0,1);
                break;
                case ("Y"):
                    rotate_axis = new Vector3D(0, 1, 0);
                break;
                case ("Z"):
                    rotate_axis = new Vector3D(1, 0, 0);
                break;                
            }
            Quaternion rotation = new Quaternion(rotate_axis, steps * 90);
            Console.WriteLine("Rotation Y: " + coord.RadianToDegrees(coord.quat_to_radians(rotation).Y));
            Console.WriteLine("Rotation X: " + coord.RadianToDegrees(coord.quat_to_radians(rotation).X));
            Console.WriteLine("Rotation Z: " + coord.RadianToDegrees(coord.quat_to_radians(rotation).Z));
            quat = rotation * quat;
            Console.WriteLine("result Y: " + coord.RadianToDegrees(coord.quat_to_radians(quat).Y));
            Console.WriteLine("result X: " + coord.RadianToDegrees(coord.quat_to_radians(quat).X));
            Console.WriteLine("result Z: " + coord.RadianToDegrees(coord.quat_to_radians(quat).Z));
            X = quat.X;
            Y = quat.Y;
            Z = quat.Z;
            W = quat.W;
            Console.WriteLine("New Quat: " + this.ToString());
        }

        public void rotate_coord(string axis,int steps=1){
            string A = "";
            string B = "";
            switch (axis)
            {
                case "X": 
                    A = "Y";
                    B = "Z";
                break;
                case "Y":
                    A = "X";
                    B = "Z";
                break;
                case "Z":
                    A = "X";
                    B = "Y";
                break;
            }            
            //Console.WriteLine("A is " + A + " B is " + B);
            //do rotation as per http://www.mathwarehouse.com/transformations/rotations-in-math.php
            //Console.WriteLine("before first step"+this.ToString());
            double buffer = this.getValue(A);
            this.setValue(A, this.getValue(B));
            this.setValue(B, buffer);
            //Console.WriteLine("after first step "+this.ToString());
            switch (steps){
                case 1:
                    //Console.Write(Y+" ");
                    this.setValue(A, -this.getValue(A));
                    //Console.WriteLine(Y);
                break;
                case 2:                    
                    this.setValue(B, -(this.getValue(B)));
                    this.setValue(A, -(this.getValue(A)));
                break;
                case 3:                    
                    this.setValue(B, -(this.getValue(B)));
                break;
                default:                    
                    this.setValue(A, -this.getValue(A));
                break;
            }
            

            
        }



    }
}
