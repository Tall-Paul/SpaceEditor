using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Media.Media3D;


namespace SpaceEditor
{
    class MathStuff
    {
        public static double DegreesToRadians(double angle)
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

        public static Vector3D diff_quats(Quaternion quat1, Quaternion quat2){
            Vector3D v1 = stupid_quat_to_angles(quat1);
            Vector3D v2 = stupid_quat_to_angles(quat2);
            return v1 - v2;
        }

        public static Vector3D niceifyAngles(Vector3D v1)
        {
            double x = v1.X;
            double y = v1.Y;
            double z = v1.Z;
            if (x == -90)
                x = 270;
            if (y == -90)
                y = 270;
            if (z == -90)
                z = 270;
            return new Vector3D(x, y, z);
        }

        public static Vector3D unNiceifyAngles(Vector3D v1)
        {
            double x = v1.X;
            double y = v1.Y;
            double z = v1.Z;
            if (x == 270)
                x = -90;
            if (y == 270)
                y = -90;
            if (z == 270)
                z = -90;
            if (x == -270)
                x = 90;
            if (y == -270)
                y = 90;
            if (z == -270)
                z = 90;
            return new Vector3D(x, y, z);
        }

        public static Vector3D stupid_quat_to_angles(Quaternion quat)
        {
            double round_x = Math.Round(quat.X, 1);
            double round_y = Math.Round(quat.Y, 1);
            double round_z = Math.Round(quat.Z, 1);
            double round_w = Math.Round(quat.W, 1);
            string durr = round_x + " " + round_y + " " + round_z + " " + round_w;
            switch (durr) {
                case "0 0 0 1":
                    return new Vector3D(0,0,0);
                case "0 0 0.7 0.7":
                    return new Vector3D(0,0,90);
                case "0 0 1 0":
                    return new Vector3D(0,0,180);
                case "0 0 -0.7 0.7":
                    return new Vector3D(0,0,-90);
                case "0 0.7 0 0.7":
                    return new Vector3D(0,90,0);
                case "0.5 0.5 0.5 0.5":
                    return new Vector3D(0,90,90);
                case "0.7 0 0.7 0":
                    return new Vector3D(0,90,180);
                case "-0.5 0.5 -0.5 0.5":
                    return new Vector3D(0,90,-90);
                case "0 1 0 0":
                    return new Vector3D(0,180,0);
                case "0.7 0.7 0 0":
                    return new Vector3D(0,180,90);
                case "1 0 0 0":
                    return new Vector3D(0,180,180);
                case "-0.7 0.7 0 0":
                    return new Vector3D(0,180,-90);
                case "0 -0.7 0 0.7":
                    return new Vector3D(0,-90,0);
                case "-0.5 -0.5 0.5 0.5":
                    return new Vector3D(0,-90,90);
                case "-0.7 0 0.7 0":
                    return new Vector3D(0,-90,180);
                case "0.5 -0.5 -0.5 0.5":
                    return new Vector3D(0,-90,-90);
                case "0.7 0 0 0.7":
                    return new Vector3D(90,0,0);
                case "0 0.7 0.7 0":
                    return new Vector3D(90,0,180);                
                case "0.5 0.5 -0.5 0.5":
                    return new Vector3D(90,90,0);
                case "0.5 0.5 0.5 -0.5":
                    return new Vector3D(90,90,180);            
                case "0 0.7 -0.7 0":
                    return new Vector3D(90,180,0);
                case "0.5 0.5 -0.5 -0.5":
                    return new Vector3D(90,180,90);
                case "0.7 0 0 -0.7":
                    return new Vector3D(90,180,180);
                case "0.5 -0.5 0.5 0.5":
                    return new Vector3D(90,-90,0);                
case "-0.5 0.5 0.5 0.5":
return new Vector3D(90,-90,180);
case "0.7 -0.7 0 0":
return new Vector3D(90,-90,-90);
case "0.7 0 -0.7 0":
return new Vector3D(180,90,0);
case "0 0.7 0 -0.7":
return new Vector3D(180,90,180);
case "0 0 -1 0":
return new Vector3D(180,180,0);
case "0 0 -0.7 -0.7":
return new Vector3D(180,180,90);
case "0 0 0 -1":
return new Vector3D(180,180,180);
case "0.5 -0.5 0.5 -0.5":
return new Vector3D(180,-90,-90);
case "-0.7 0 0 0.7":
return new Vector3D(-90,0,0);

case "0 -0.7 0.7 0":
return new Vector3D(-90,0,180);
case "-0.5 0.5 0.5 -0.5":
return new Vector3D(-90,180,-90);
case "-0.5 -0.5 -0.5 0.5":
return new Vector3D(-90,-90,0);
case "-0.7 -0.7 0 0":
return new Vector3D(-90,-90,90);
case "-0.5 -0.5 0.5 -0.5":
return new Vector3D(-90,-90,180);
            }
            return new Vector3D(0, 0, 0);
        }

        public static int AngleToSteps(double actual_angle)
        {
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

        public static int RadianToSteps(double angle)
        {
            double actual_angle = angle * (180.0 / Math.PI); //converts to degrees
            return AngleToSteps(actual_angle);
            

        }

        public static Quaternion quat_from_angles(double x_angle, double y_angle, double z_angle)
        {
            //convert to radians
            x_angle = DegreesToRadians(x_angle);
            y_angle = DegreesToRadians(y_angle);
            z_angle = DegreesToRadians(z_angle);
            double c1 = Math.Cos(y_angle / 2);
            double s1 = Math.Sin(y_angle / 2);
            double c2 = Math.Cos(z_angle / 2);
            double s2 = Math.Sin(z_angle / 2);
            double c3 = Math.Cos(x_angle / 2);
            double s3 = Math.Sin(x_angle / 2);
            double c1c2 = c1 * c2;
            double s1s2 = s1 * s2;
            double w = c1c2 * c3 - s1s2 * s3;
            double x = c1c2 * s3 + s1s2 * c3;
            double y = s1 * c2 * c3 + c1 * s2 * s3;
            double z = c1 * s2 * c3 - s1 * c2 * s3;
            return new Quaternion(x, y, z, w);
        }

    }
}
