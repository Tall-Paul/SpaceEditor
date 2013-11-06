using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRageMath;


namespace SpaceEditor
{
    class vrageMath
    {
        public static Vector3 quat_to_angles(Quaternion quat)
        {
            Matrix test = Matrix.CreateFromQuaternion(quat);
            Vector3 vec = new Vector3();
            Matrix.GetEulerAnglesXYZ(ref test, out vec);
            //Console.WriteLine(MathHelper.ToDegrees(vec.X) + " " + MathHelper.ToDegrees(vec.Y) + " " + MathHelper.ToDegrees(vec.Z));
            return vec;            
        }

        public static Vector3 diff_quats(Quaternion quat1, Quaternion quat2){
            Vector3 vec1 = vrageMath.quat_to_angles(quat1);
            Vector3 vec2 = vrageMath.quat_to_angles(quat2);
            Vector3 vec = vec1 - vec2;
            //Console.WriteLine(MathHelper.ToDegrees(vec.X) + " " + MathHelper.ToDegrees(vec.Y) + " " + MathHelper.ToDegrees(vec.Z));
            return vec;
        }

        public static Quaternion rotateQuat(Quaternion quat1, string Axis, float angle)
        {
            //if (angle == 270)
            //    angle = -90;
            Console.WriteLine("Angle: " + angle);
            Quaternion rotation = Quaternion.CreateFromYawPitchRoll(0, 0, 0);
            switch (Axis)
            {
                case "X":
                    rotation = Quaternion.CreateFromYawPitchRoll(VRageMath.MathHelper.ToRadians(angle), 0, 0);
                break;
                case "Y":
                rotation = Quaternion.CreateFromYawPitchRoll(0, VRageMath.MathHelper.ToRadians(angle), 0);
                break;
                case "Z":
                    //rotation = Quaternion.CreateFromAxisAngle(new Vector3(0, 0, 1), VRageMath.MathHelper.ToRadians(angle));
                    rotation = Quaternion.CreateFromYawPitchRoll(0, 0, VRageMath.MathHelper.ToRadians(angle));
                break;
            }

            //Console.Write("Input quat = ");
            //vrageMath.quat_to_angles(quat1);
            //Console.Write("Rotation quat = ");
            //vrageMath.quat_to_angles(rotation);
            Quaternion result = quat1 * rotation;
            //Console.Write("Result quat = ");
            //vrageMath.quat_to_angles(result);
            return result;            
        }

        public static int AngleToSteps(float actual_angle)
        {
            actual_angle = MathHelper.ToDegrees(actual_angle);
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
        

    }
}
