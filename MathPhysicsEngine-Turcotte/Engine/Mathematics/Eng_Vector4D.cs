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
            W = 0;
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
            W = 0;
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

        //Part 3: 5.a - Multiplying a 4D vector by a Quaternion.
        //              HINT: Create a 4D vector from a 3D vector.

        #endregion
    }//eoc
}//eon
