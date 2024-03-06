using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Quaternion
    {
        //1.a - Properties.
        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //2.a - Empty Constructor.
        public Eng_Quaternion()
        {
            W = 0;
            X = 0;
            Y = 0;
            Z = 0;
        }//eom

        //2.b - Create from input of 4 values (make sure the magnitude = 1).
        public Eng_Quaternion(double w, double x, double y, double z)
        {
            double magnitude;

            magnitude = Math.Sqrt(Math.Pow(w,2) + Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

            if (magnitude != 1)
            {
                throw new ArgumentOutOfRangeException("The magnitude of a quaternion must be 1 for it to be valid. inputted numbers do not make a valid quaternion");
            }
            else
            {
                W = w;
                X = x;
                Y = y; 
                Z = z;
            }
        }//eom

        //2.c - Create from roll, pitch, and yaw angles (all in degrees).
        public Eng_Quaternion(double rollDeg, double pitchDeg, double yawDeg)
        {
            //convert all deg's to radians so they will work with Math. Functions then /2 because Quaternions are like that

            rollDeg = Functions.DegreesToRadians(rollDeg)/2;
            pitchDeg = Functions.DegreesToRadians(pitchDeg)/2;
            yawDeg = Functions.DegreesToRadians(yawDeg)/2;

            W = ((Math.Cos(yawDeg) * Math.Cos(pitchDeg) * Math.Cos(rollDeg)) + (Math.Sin(yawDeg) * Math.Sin(pitchDeg) * Math.Sin(rollDeg)));
            X = ((Math.Cos(yawDeg) * Math.Sin(pitchDeg) * Math.Cos(rollDeg)) + (Math.Sin(yawDeg) * Math.Cos(pitchDeg) * Math.Sin(rollDeg)));
            Y = ((Math.Sin(yawDeg) * Math.Cos(pitchDeg) * Math.Cos(rollDeg)) - (Math.Cos(yawDeg) * Math.Sin(pitchDeg) * Math.Sin(rollDeg)));
            Z = ((Math.Cos(yawDeg) * Math.Cos(pitchDeg) * Math.Sin(rollDeg)) - (Math.Sin(yawDeg) * Math.Sin(pitchDeg) * Math.Cos(rollDeg)));
        }//eom
        #region Class Methods
        //3.a - Create Matrix from Quaternion.
        public Eng_Matrix4x4 ConvertToMatrix()
        {
            return new Eng_Matrix4x4((1 - 2 * (Math.Pow(Y, 2) + Math.Pow(Z, 2))), (2 * ((X * Y) - (W * Z))), (2 * ((X * Z) + (W * Y))), 0,
                                     (2 * ((X * Y) + (W * Y))), (1 - 2 * (Math.Pow(X, 2) + Math.Pow(Z, 2))), (2 * ((Y * Z) - (W * X))), 0,
                                     (2 * ((X * Z) - (W * Y))), (2 * ((Y * Z) + (W * X))), (1 - 2 * (Math.Pow(X, 2) + Math.Pow(Y, 2))), 0,
                                                    0,                        0,                                    0,                  1);

        }//end of ConvertToMatrix

        //3.b - Create rotation angles (in degrees) from Quaternion.
        public Tuple<double, double, double> ConvertToEuler()
        {
            double roll, pitch, yaw;

            roll = Math.Atan((2 * ((X * Y) + (W * Z))) / (1 - 2 * (Math.Pow(X, 2) + Math.Pow(Y, 2))));
            pitch = Math.Asin(-2 * ((Y * Z) - (W * X)));
            yaw = Math.Atan(2 * ((X * Z) + (W * Y)) / (1 - 2 * (Math.Pow(X, 2) + Math.Pow(Y, 2))));

            roll = Functions.RadiansToDegrees(roll);
            pitch = Functions.RadiansToDegrees(pitch);
            yaw = Functions.RadiansToDegrees(yaw);

            return Tuple.Create(roll, pitch, yaw);
        }//end of ConvertToEuler
        #endregion

        #region Overload Operators
        #region Complier Warning Fix
        // the following two methods are to remove the CS0660 and CS0661 compiler warnings
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
        {
            return true;
        }//eom
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override int GetHashCode()
        {
            return 0;
        }//eom
        #endregion

        //4.a - Equality of two Quaternions.
        public static bool operator ==(Eng_Quaternion a, Eng_Quaternion b)
        {
            return a.W == b.W && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        //4.b - Inequality of two Quaternions.
        public static bool operator !=(Eng_Quaternion a, Eng_Quaternion b)
        {
            return a.W != b.W || a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }
        #endregion
    }//eoc
}//eon
