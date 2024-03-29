using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Vector4D
    {
        //5.a - Properties.
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }
        //5.b - Empty Constructor.
        public Eng_Vector4D()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 1;
        }//eom
		
		//5.c - Non-empty Constructor – all properties.
		public Eng_Vector4D(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }//eom
		
		//5.d - Non-empty Constructor (x, y, and z only).
		public Eng_Vector4D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1;
        }//eom
		
        //5e - Create a 4D vector from a 3D vector.
        public Eng_Vector4D(Eng_Vector3D v)
        {
			Eng_Vector4D nV = new Eng_Vector4D(v.X,v.Y,v.Z);
		}//eom
		
        #region Overload Operators
        #region Complier Warning Fix
        // the following two methods are to remove the CS0660 and CS0661 compiler warnings
        public override bool Equals(object obj)
        {
            return true;
        }//eom
		
        public override int GetHashCode()
        {
            return 0;
        }//eom
        #endregion

        //6.a - Equality of two 4D vectors.
        public static bool operator ==(Eng_Vector4D a, Eng_Vector4D b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
        }

        //6.b - Inequality of two 4D vectors.

        public static bool operator !=(Eng_Vector4D a, Eng_Vector4D b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z || a.W != b.W;
        }
        //6.c - Multiply 4D vector by Eng_Matrix4x4.

        public static Eng_Vector4D operator *(Eng_Vector4D v, Eng_Matrix4x4 m)
        {
            return new Eng_Vector4D((v.X * m.M11 + v.Y * m.M12 + v.Z * m.M13 + v.W * m.M14),
                                    (v.X * m.M21 + v.Y * m.M22 + v.Z * m.M23 + v.W * m.M24),
                                    (v.X * m.M31 + v.Y * m.M32 + v.Z * m.M33 + v.W * m.M34),
                                    (v.X * m.M41 + v.Y * m.M42 + v.Z * m.M43 + v.W * m.M44));
        }

        //Part 3: 5.a - Multiplying a 4D vector by a Quaternion.
        //              HINT: Create a 4D vector from a 3D vector.
        public static Eng_Vector4D operator *(Eng_Vector4D v, Eng_Quaternion q)
        {
            return new Eng_Vector4D(((q.X * v.X) + (q.W * q.Y * v.Z) - (q.Y * q.Z * v.Y) + (q.Z * q.Y * v.Z)),
                                    ((q.X * v.Y) + (q.W * q.Z * v.X) + (q.Y * q.Z * v.Z) - (q.Z * q.X * v.Y)),
                                    ((q.X * v.Z) + (q.W * q.X * v.Y) - (q.Y * q.X * v.X) + (q.Z * q.X * v.Z)));
        }
        #endregion
    }//eoc
}//eon
